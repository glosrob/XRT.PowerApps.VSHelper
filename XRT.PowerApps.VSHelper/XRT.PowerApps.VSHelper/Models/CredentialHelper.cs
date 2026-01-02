using CredentialManagement;
using System;

namespace XRT.PowerApps.VSHelper.Models
{
    internal class CredentialHelper
    {
      private const string CredentialTargetPrefix = "PowerAppsVSHelper:";

        /// <summary>
        /// Saves credentials to Windows Credential Manager
        /// </summary>
        /// <param name="environmentUrl">The PowerApps environment URL (used as part of the credential target)</param>
/// <param name="clientId">The Azure AD Client ID</param>
     /// <param name="clientSecret">The Azure AD Client Secret</param>
      internal void SaveCredentials(string environmentUrl, string clientId, string clientSecret)
 {
     if (string.IsNullOrWhiteSpace(environmentUrl))
    {
     throw new ArgumentException("Environment URL cannot be empty", nameof(environmentUrl));
 }

  using (var credential = new Credential())
            {
       credential.Target = GetCredentialTarget(environmentUrl);
    credential.Username = clientId ?? string.Empty;
    credential.Password = clientSecret ?? string.Empty;
    credential.Type = CredentialType.Generic;
 credential.PersistanceType = PersistanceType.Enterprise;
  credential.Save();
 }
        }

        /// <summary>
     /// Loads credentials from Windows Credential Manager
     /// </summary>
/// <param name="environmentUrl">The PowerApps environment URL</param>
        /// <returns>Tuple of (ClientId, ClientSecret), or (null, null) if not found</returns>
    internal (string clientId, string clientSecret) LoadCredentials(string environmentUrl)
        {
            if (string.IsNullOrWhiteSpace(environmentUrl))
            {
   return (null, null);
      }

            using (var credential = new Credential())
  {
     credential.Target = GetCredentialTarget(environmentUrl);
  credential.Type = CredentialType.Generic;

  if (credential.Load())
            {
            return (credential.Username, credential.Password);
   }

          return (null, null);
     }
     }

        /// <summary>
        /// Deletes credentials from Windows Credential Manager
     /// </summary>
        /// <param name="environmentUrl">The PowerApps environment URL</param>
        internal void DeleteCredentials(string environmentUrl)
        {
        if (string.IsNullOrWhiteSpace(environmentUrl))
            {
     return;
       }

            using (var credential = new Credential())
          {
         credential.Target = GetCredentialTarget(environmentUrl);
      credential.Type = CredentialType.Generic;
      
                if (credential.Exists())
 {
         credential.Delete();
}
  }
      }

        /// <summary>
        /// Checks if credentials exist in Windows Credential Manager
        /// </summary>
 /// <param name="environmentUrl">The PowerApps environment URL</param>
   /// <returns>True if credentials exist, false otherwise</returns>
        internal bool CredentialsExist(string environmentUrl)
        {
   if (string.IsNullOrWhiteSpace(environmentUrl))
     {
             return false;
    }

    using (var credential = new Credential())
    {
   credential.Target = GetCredentialTarget(environmentUrl);
        credential.Type = CredentialType.Generic;
        return credential.Exists();
          }
        }

        /// <summary>
      /// Generates the credential target name
        /// </summary>
   private string GetCredentialTarget(string environmentUrl)
        {
       // Normalize the URL (remove trailing slashes, convert to lowercase for consistency)
    var normalized = environmentUrl.TrimEnd('/').ToLowerInvariant();
            return $"{CredentialTargetPrefix}{normalized}";
        }
    }
}
