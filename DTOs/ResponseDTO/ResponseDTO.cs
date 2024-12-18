using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace vrumvrum.DTOs.ResponseDTO;

public class ResponseDTO<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public string Mensagem { get; set; }
    public T? Dados { get; set; }
}