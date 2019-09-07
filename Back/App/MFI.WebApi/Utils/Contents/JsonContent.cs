using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MFI.WebApi.Utils.Contents
{
    /// <summary>
    /// Transforma entidades em objetos json.
    /// </summary>
    public class JsonContent : HttpContent
    {
        /// <summary>
        /// Armazena stream de um objeto.
        /// </summary>
        private readonly MemoryStream _stream = new MemoryStream();

        /// <summary>
        /// Converte objeto qualquer em um objeto jason.
        /// </summary>
        /// <param name="value">Obketo para conversão.</param>
        public JsonContent(object value)
        {
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var jw = new JsonTextWriter(new StreamWriter(this._stream));
            jw.Formatting = Formatting.Indented;
            var serializer = new JsonSerializer();
            serializer.Serialize(jw, value);
            jw.Flush();
            this._stream.Position = 0;
        }

        /// <summary>
        ///  Serialize the HTTP content to a stream as an asynchronous operation.
        /// </summary>
        /// <param name="stream"> The target stream.</param>
        /// <param name="context"> Information about the transport (channel binding token, for example). This parameter
        ///     may be nul</param>
        /// <returns>Objeto assincrono do stream.</returns>
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            return this._stream.CopyToAsync(stream);
        }

        /// <summary>
        ///  Determines whether the HTTP content has a valid length in bytes.
        /// </summary>
        /// <param name="length">The length in bytes of the HHTP content.</param>
        /// <returns>System.Boolean.true if length is a valid length; otherwise, false.</returns>
        protected override bool TryComputeLength(out long length)
        {
            length = this._stream.Length;
            return true;
        }
    }
}