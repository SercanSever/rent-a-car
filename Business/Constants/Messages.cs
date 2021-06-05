using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Başarıyla Eklendi.";
        public static string NotAdded = "Ekleme Başarısız.";
        public static string NotValid = "Geçersiz İşlem.";
        public static string Delete = "Başarıyla Silindi.";
        public static string Update = "Başarıyla Güncellendi.";
        public static string MaintenanceTime = "Bakım Saati.";
        public static string List = "Başarıyla Listelendi.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string SuccessFullLogin = "Giriş Başarılı.";
        public static string PaswordError = "Hatalı Şifre Girdiniz.";
        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        public static string UserAlreadyExists = "Kullanıcı zaten kayıtlı.";
        public static string AccessTokenCreated = "Token Başarıyla Oluşturuldu.";
    }
}
