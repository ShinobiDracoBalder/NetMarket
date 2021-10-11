namespace WebApi.Controllers
{
    internal class CodeErrorResponse
    {
        private int v1;
        private string v2;

        public CodeErrorResponse(int v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}