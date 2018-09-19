using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Security.Claims;
using Microsoft.Owin.Security;

using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GRADEXPO.Models
{
    public class AdAuthenticationService
    {
        public class AuthenticationResult
        {
            public AuthenticationResult(string errorMessage = null)
            {
                ErrorMessage = errorMessage;
            }

            public String ErrorMessage { get; private set; }
            public Boolean IsSuccess => String.IsNullOrEmpty(ErrorMessage);
        }

        private readonly IAuthenticationManager authenticationManager;

        public AdAuthenticationService(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }


        /// <summary>
        /// Check if username and password matches existing account in AD. 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AuthenticationResult SignIn(String username, String password, string serverPath)
        {
#if DEBUG
            // authenticates against your local machine - for development time
            ContextType authenticationType = ContextType.Domain;
#else
            // authenticates against your Domain AD
            ContextType authenticationType = ContextType.Domain;
#endif
            if (username.Contains("\\"))
            {
                username = username.Split(new char[] { '\\' })[1];
            }
            PrincipalContext principalContext = new PrincipalContext(authenticationType, @"gradient.ru", "DC=gradient,DC=ru", username, password);
            bool isAuthenticated = false;
            UserPrincipal userPrincipal = null;
            try
            {
                userPrincipal = UserPrincipal.FindByIdentity(principalContext, username);
                if (userPrincipal != null)
                {
                    isAuthenticated = principalContext.ValidateCredentials(username, password, ContextOptions.Negotiate);
                    DirectoryEntry directoryEntry = (DirectoryEntry)userPrincipal.GetUnderlyingObject();
                    PropertyValueCollection collection = directoryEntry.Properties["thumbnailPhoto"];
                    if (collection.Value != null && collection.Value is byte[])
                    {
                        byte[] thumbnailInBytes = (byte[])collection.Value;
                        Bitmap thumbnail = new Bitmap(new MemoryStream(thumbnailInBytes));
                        string fileName = username; ;
                        if (username.Contains("\\"))
                        {
                            fileName = username.Split(new char[] { '\\' })[1];
                        }
                        String saveImagePath = string.Format("{0}/{1}.jpg", serverPath, fileName);
                        thumbnail.Save(saveImagePath, ImageFormat.Jpeg);
                    }
                }
            }
            catch (Exception e)
            {
                isAuthenticated = false;
                userPrincipal = null;
            }

            if (!isAuthenticated || userPrincipal == null)
            {
                return new AuthenticationResult("Неверный логин или пароль");
            }

            if (userPrincipal.IsAccountLockedOut())
            {
                // here can be a security related discussion weather it is worth 
                // revealing this information
                return new AuthenticationResult("Ваша учетная запись заблокирована.");
            }

            if (userPrincipal.Enabled.HasValue && userPrincipal.Enabled.Value == false)
            {
                // here can be a security related discussion weather it is worth 
                // revealing this information
                return new AuthenticationResult("Ваша учетная запись отключена");
            }
            
            var identity = CreateIdentity(userPrincipal);

            authenticationManager.SignOut(MyAuthentication.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);


            return new AuthenticationResult();
        }
        
        
        private ClaimsIdentity CreateIdentity(UserPrincipal userPrincipal)
        {
            var identity = new ClaimsIdentity(MyAuthentication.ApplicationCookie, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "Active Directory"));
            identity.AddClaim(new Claim(ClaimTypes.Name, userPrincipal.Name));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userPrincipal.SamAccountName));
            if (!String.IsNullOrEmpty(userPrincipal.EmailAddress))
            {
                identity.AddClaim(new Claim(ClaimTypes.Email, userPrincipal.EmailAddress));
            }

            // add your own claims if you need to add more information stored on the cookie
            identity.Label = userPrincipal.SamAccountName;
            return identity;
        }
    }
}