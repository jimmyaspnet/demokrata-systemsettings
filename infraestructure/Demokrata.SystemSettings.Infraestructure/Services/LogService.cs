namespace Demokrata.SystemSettings.Infraestructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LogService
{
    private readonly HttpClient httpClient;

    public LogService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
}
