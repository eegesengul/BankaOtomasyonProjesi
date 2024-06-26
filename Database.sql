USE [JXBankDatabase]
GO
/****** Object:  Table [dbo].[kullaniciBilgileri]    Script Date: 31.05.2024 18:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullaniciBilgileri](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[tcNo] [bigint] NULL,
	[adSoyad] [nvarchar](50) NULL,
	[adres] [nvarchar](50) NULL,
	[telefon] [nvarchar](50) NULL,
	[sifre] [nvarchar](50) NULL,
	[bakiye] [decimal](18, 2) NULL,
	[durum] [bigint] NULL,
	[cinsiyet] [nvarchar](50) NULL,
	[meslek] [nvarchar](50) NULL,
 CONSTRAINT [PK_musteriler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullaniciHareketleri]    Script Date: 31.05.2024 18:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullaniciHareketleri](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[musteriID] [int] NOT NULL,
	[islem] [nvarchar](50) NULL,
	[tarih] [date] NULL,
 CONSTRAINT [PK_hareketler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[kullaniciBilgileri] ON 

INSERT [dbo].[kullaniciBilgileri] ([ID], [tcNo], [adSoyad], [adres], [telefon], [sifre], [bakiye], [durum], [cinsiyet], [meslek]) VALUES (2, 11111111111, N'emre sarac', N'maras', N'5551111111', N'102030', CAST(1385.00 AS Decimal(18, 2)), 1, N'Erkek', N'Öğrenci')
INSERT [dbo].[kullaniciBilgileri] ([ID], [tcNo], [adSoyad], [adres], [telefon], [sifre], [bakiye], [durum], [cinsiyet], [meslek]) VALUES (1004, 44444444444, N'Şaban Şengül', N'izmir', N'2222222222', N'102030', CAST(999060.00 AS Decimal(18, 2)), 1, N'Erkek', N'Öğrenci')
INSERT [dbo].[kullaniciBilgileri] ([ID], [tcNo], [adSoyad], [adres], [telefon], [sifre], [bakiye], [durum], [cinsiyet], [meslek]) VALUES (11006, 77777777777, N'zeynep ercan', N'ankara', N'5373565058', N'7869587543', CAST(18927.00 AS Decimal(18, 2)), 1, N'Kadın', N'Öğrenci')
INSERT [dbo].[kullaniciBilgileri] ([ID], [tcNo], [adSoyad], [adres], [telefon], [sifre], [bakiye], [durum], [cinsiyet], [meslek]) VALUES (31016, 22222222223, N'Muhammet Keskin', N'ankara', N'5551111112', N'10203040', CAST(10.00 AS Decimal(18, 2)), 1, N'(Belirtilmemis)', N'Öğrenci')
INSERT [dbo].[kullaniciBilgileri] ([ID], [tcNo], [adSoyad], [adres], [telefon], [sifre], [bakiye], [durum], [cinsiyet], [meslek]) VALUES (41018, 33333333333, N'Ege Şengül', N'izmir', N'1111111111', N'33333333333', CAST(999060.00 AS Decimal(18, 2)), 1, N'Erkek', N'Öğrenci')
INSERT [dbo].[kullaniciBilgileri] ([ID], [tcNo], [adSoyad], [adres], [telefon], [sifre], [bakiye], [durum], [cinsiyet], [meslek]) VALUES (51017, 98765432111, N'Gülce Duru Koç', N'ankara', N'5333575768', N'98765432111', CAST(500000.00 AS Decimal(18, 2)), 1, N'Kadın', N'bilgo müho')
SET IDENTITY_INSERT [dbo].[kullaniciBilgileri] OFF
GO
SET IDENTITY_INSERT [dbo].[kullaniciHareketleri] ON 

INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (3032, 2, N'10 TL Havale/EFT göndericiden alındı.', CAST(N'2024-05-24' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4005, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4006, 2, N'50 TL Para yatırma işlemi yapıldı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4007, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4008, 2, N'70 TL Para çekim işlemi yapıldı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4009, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4010, 2, N'50 TL Para yatırma işlemi yapıldı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4011, 2, N'50 TL Para yatırma işlemi yapıldı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4012, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4013, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4014, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4015, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4016, 2, N'50 TL Para yatırma işlemi yapıldı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4017, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4018, 2, N'50 TL Para yatırma işlemi yapıldı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4019, 2, N'50 TL Para yatırma işlemi yapıldı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4020, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4021, 2, N'50 TL Para yatırma işlemi yapıldı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4022, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4023, 2, N'50 TL Para yatırma işlemi yapıldı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4024, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4025, 2, N'30 TL Para çekim işlemi yapıldı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4026, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4027, 2, N'20 TL Havale/EFT alıcıya gönderildi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4029, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4030, 2, N'Şifre değiştirme işlemi yapıldı', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4038, 2, N'100 TL Havale/EFT göndericiden alındı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4041, 1004, N'Şifre değiştirme işlemi yapıldı', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4042, 1004, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4043, 1004, N'50 TL Para yatırma işlemi yapıldı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4044, 1004, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4045, 1004, N'49 TL Para çekim işlemi yapıldı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4046, 1004, N'1000 TL Havale/EFT alıcıya gönderildi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4048, 1004, N'Şifre değiştirme işlemi yapıldı', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4049, 1004, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4050, 1004, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4051, 1004, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4052, 1004, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4053, 1004, N'Bakiye görüntülendi.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (4054, 1004, N'60 TL Para yatırma işlemi yapıldı.', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (5032, 31016, N'Bakiye görüntülendi.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (5033, 31016, N'50 TL Para yatırma işlemi yapıldı.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (5034, 31016, N'20 TL Para çekim işlemi yapıldı.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (5035, 31016, N'Bakiye görüntülendi.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (5036, 31016, N'50 TL Havale/EFT alıcıya gönderildi.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (5037, 2, N'50 TL Havale/EFT göndericiden alındı.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (5038, 31016, N'Şifre değiştirme işlemi yapıldı', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6032, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6033, 2, N'50 TL Para yatırma işlemi yapıldı.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6034, 2, N'35 TL Para çekim işlemi yapıldı.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6035, 2, N'100 TL Havale/EFT alıcıya gönderildi.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6036, 11006, N'100 TL Havale/EFT göndericiden alındı.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6037, 2, N'Bakiye görüntülendi.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6038, 2, N'Şifre değiştirme işlemi yapıldı', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6039, 31016, N'Bakiye görüntülendi.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6040, 31016, N'50 TL Para yatırma işlemi yapıldı.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6041, 31016, N'50 TL Para çekim işlemi yapıldı.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6042, 31016, N'Bakiye görüntülendi.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6043, 31016, N'20 TL Havale/EFT alıcıya gönderildi.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6044, 2, N'20 TL Havale/EFT göndericiden alındı.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6045, 31016, N'Şifre değiştirme işlemi yapıldı', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6046, 31016, N'Bakiye görüntülendi.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6047, 31016, N'Bakiye görüntülendi.', CAST(N'2024-05-27' AS Date))
INSERT [dbo].[kullaniciHareketleri] ([ID], [musteriID], [islem], [tarih]) VALUES (6048, 51017, N'Bakiye görüntülendi.', CAST(N'2024-05-28' AS Date))
SET IDENTITY_INSERT [dbo].[kullaniciHareketleri] OFF
GO
ALTER TABLE [dbo].[kullaniciHareketleri]  WITH CHECK ADD  CONSTRAINT [FK_kullaniciHareketleri_kullaniciBilgileri] FOREIGN KEY([musteriID])
REFERENCES [dbo].[kullaniciBilgileri] ([ID])
GO
ALTER TABLE [dbo].[kullaniciHareketleri] CHECK CONSTRAINT [FK_kullaniciHareketleri_kullaniciBilgileri]
GO
