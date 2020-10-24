using System;

namespace ClientTokenAuthentication
{
    public class TokenUser
    {
        /// <summary>
        /// Client/User ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Authentication token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Token description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Token created time UTC
        /// </summary>
        public DateTime CreatedUTC { get; set; }

        /// <summary>
        /// Token expiration time UTC
        /// </summary>
        public DateTime ExpiresUTC { get; set; }
    }
}