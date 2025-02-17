﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERPProject.Entity.Result
{
    public class Sonuc<T>
    {
        public Sonuc(T _data, string _mesaj, int _statusCode, HataBilgisi _hataBilgisi)
        {
            Data = _data;
            Mesaj = _mesaj;
            StatusCode = _statusCode;
            HataBilgisi = _hataBilgisi;
        }

        public Sonuc(string _mesaj, int _statusCode, HataBilgisi _hataBilgisi)
        {
            Mesaj = _mesaj;
            StatusCode = _statusCode;
            HataBilgisi = _hataBilgisi;
        }

        public Sonuc(int _statusCode, HataBilgisi _hataBilgisi)
        {
            StatusCode = _statusCode;
            HataBilgisi = _hataBilgisi;
        }

        public T Data { get; set; }

        public string Mesaj { get; set; }

        public int StatusCode { get; set; }

        public HataBilgisi HataBilgisi { get; set; }

        public static Sonuc<T> Error(string message = "Hata Oluştu", int statusCode = (int)HttpStatusCode.InternalServerError)
        {
            return new Sonuc<T>(message, statusCode, HataBilgisi.Error());
        }
        public static Sonuc<T> SuccessWithData(T data, string message = "İşlem Başarılı", int statusCode = (int)HttpStatusCode.OK)
        {
            return new Sonuc<T>(data, message, statusCode,null);
        }

        public static Sonuc<T> SuccessWithoutData(string message = "İşlem Başarılı", int statusCode = (int)HttpStatusCode.OK)
        {
            return new Sonuc<T>(message, statusCode, null);
        }
        

        public static Sonuc<T> SuccessNoDataFound(string message = "Sonuç Bulunamadı", int statusCode = (int)HttpStatusCode.NotFound)
        {
            return new Sonuc<T>(message, statusCode, HataBilgisi.NotFound());
        }

        public static Sonuc<T> FieldValidationError(HataBilgisi hataBilgisi, int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new Sonuc<T>("Hata Oluştu", statusCode, hataBilgisi);
        }

        public static Sonuc<T> TokenNotFound()
        {
            return new Sonuc<T>("Hata Oluştu", (int)HttpStatusCode.Unauthorized, HataBilgisi.TokenNotFoundError());
        }

        public static Sonuc<T> ExistingError(string message = "Hata Oluştu", int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new Sonuc<T>(message, statusCode, HataBilgisi.Error());
        }

        public static Sonuc<T> AlreadyExistError(string message = "Aynı yetkiden birden fazla eklenemez.", int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new Sonuc<T>(message, statusCode, HataBilgisi.Error());
        }

    }
}
