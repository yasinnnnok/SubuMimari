﻿namespace SUBU.Models.diger
{
    //DataResult yapısı için kullanacağız
    public class ResponseResult<T>
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; } = new List<string>(); //bir daha new lememek için
        public T Data { get; set; }
    }

    public class Messages
    {
        public const string UserNotFound = "Kullanıcı bulunmadı.";
        public const string DataListed = "Veriler listelendi.";
        public const string CityIsExists = "Şehir zaten mevcuttur.";
        public const string ParameterRequired = "Parametre eksik gönderildi.";
        public const string NotFound = "Kayıt bulunmadı.";
    }
}

