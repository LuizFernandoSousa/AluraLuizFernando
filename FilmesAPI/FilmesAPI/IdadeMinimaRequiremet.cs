using Microsoft.AspNetCore.Authorization;

namespace FilmesAPI
{
    internal class IdadeMinimaRequiremet : IAuthorizationRequirement
    {
        private int v;

        public IdadeMinimaRequiremet(int v)
        {
            this.v = v;
        }
    }
}