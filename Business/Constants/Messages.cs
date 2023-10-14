using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //CAR MESSAGES//
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDetail = "Araba detayları getirildi";
        public static string CarNameInvalid = "Araba adı en az iki karakterden oluşmalı";
        public static string CarPriceIsNegative = "Araba günlük fiyatı 0'dan büyük olmalıdır";
        public static string CarsListed = "Arabalar listelendi";

        //BRAND MESSAGES
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandNameInvalid = "Marka adı en az iki karakterden oluşmalı";

        //COLOR MESSAGES
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorNameInvalid = "Renk adı en az iki karakterden oluşmalı";

        //RENTAL MESSAGES
        public static string CarNotReturn = "İstediğiniz araç henüz teslim edilmemiş";
        public static string RentalAdded = "Araç Kiralandı";
        public static string RentalUpdated = "Araç bilgileri güncellendi";
        public static string RentalDeleted = "Araç teslim edildi";

        //CUSTOMER MESSAGES
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";

        //USER MESSAGES
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserNameInvalid = "Renk adı en az iki karakterden oluşmalı";
        public static string UserGetAll = "Tüm kullanıcılar listelendi";

        //CARIMAGES MESSAGES
        public static string CarImageLimitReached= "Resim ekleme sınırı daha fazla resim ekleyemezsiniz";
        public static string CarImageAlreadyHave = "Araba zaten mevcut";
        public static string CarImageAdded = "Resim eklendi";
        public static string CarImageDeleted = "Resim silindi";
        public static string ImagesListed = "Resimler listelendi";
        public static string ImageUpdated = "Resim güncellendi";
        public static string ImagesListedByCarId = "Resim Id'ye göre listelendi";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
