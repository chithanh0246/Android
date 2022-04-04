

create database BMIApp
go
use BMIApp
go

create table Loai(
	IdLoai int identity primary key,
	TenLoai nvarchar(50)
)
 create table BaiTap(
 IdBT int identity(1,1) primary key,
 IdLoai int,
 TenBaiTap nvarchar(50),
 Hinh varchar(500),
 NoiDung nvarchar(500),
 SoHiep int,
 SoLanTap int
 foreign key (IdLoai) references Loai(IdLoai)
 )
 go

create table ThucDon(
	IdTD int identity primary key,
	IdLoai int,
	TenMonAn nvarchar(50),
	Hinh varchar(500),
	calo float ,
	foreign key (IdLoai) references Loai(IdLoai)
)
go

create table LoaiTK(
	IdLoai int identity primary key,
	Loai varchar(50)
)
go

create table TaiKhoan(
	IdTK int identity(1,1) primary key,
	Email varchar(50) ,
	Pass varchar(50),
	HoTen nvarchar(50),
	IdLoai int
	foreign key (IdLoai) references LoaiTK(IdLoai)
)
go

create table SoLieu(
	IdSL int identity primary key ,
	ChieuCao int,
	CanNang int,
	IdTK int,
	foreign key (IdTK) references TaiKhoan(IdTK)

)
go
insert into Loai values(N'Tăng cân')
insert into Loai values(N'giảm cân')

insert into LoaiTK values ('Admin')
insert into LoaiTK values ('User')
 
insert into TaiKhoan values ('T@gmail.com','123',N'Nguyễn Chí Thành',1)
insert into TaiKhoan values ('A@gmail.com','123',N'Nguyễn Văn A',2)


insert into ThucDon values(2,N'Bí ngô','https://file.hstatic.net/1000185761/file/bi-ngo-nho_grande.jpg',26)
insert into ThucDon values(1,N'Bơ','https://file.hstatic.net/1000185761/file/trai-bo_62fcd0a1111c4426883628bcc2952129.jpg',160)
insert into ThucDon values(1,N'Đậu nành','https://images.sieuthitaigia.vn/anh-seo-tin-tuc/2021/10/19/100g-dau-nanh-chua-bao-nhieu-calo-2.jpg',400)
insert into ThucDon values(1,N'Khoai lang','https://vcdn1-giadinh.vnecdn.net/2013/12/21/anh-9211-1387615838.jpg?w=680&h=0&q=100&dpr=1&fit=crop&s=aH8uqPtb6sC-q8TJWLB0dA',85.8)
insert into ThucDon values(2,N'Sữa tươi','https://toshiko.vn/wp-content/uploads/2021/07/uong-sua-tuoi-khong-duong-co-map-khong-1.jpg',43.3)
insert into ThucDon values(1,N'Yến mạch','https://www.tuticare.com/media/news/1003_Choynmchtrnsachobbtundm4.jpg',348)
insert into ThucDon values(1,N'Bơ đậu phộng','https://file.hstatic.net/1000185761/file/bo-dau-phong_grande.jpg',588.4)
insert into ThucDon values(1,N'Cơm gạo lứt','https://tieudung.vn/upload_images/images/2021/11/24/gao1.jpg',218)
insert into ThucDon values(1,N'Trứng',' https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR8mWgykmUFF0lYaQ6ZqxEKUx8omfcnzDuokA&usqp=CAU',155.1)
insert into ThucDon values(1,N'Thịt lợn nạc',' https://img.golist.vn/images/1991/1995/2502260525002.jpg',271)
insert into ThucDon values(1,N'Ức gà','https://www.huongnghiepaau.com/wp-content/uploads/2020/08/che-bien-uc-ga-giam-can.jpg',165)
insert into ThucDon values(2,N'Cá ngừ','https://media.vov.vn/uploaded/69lwz2nmezg/2019_07_08/2_bhfg.jpg',130)

 insert into BaiTap values(1,N'Gập bụng','https://www.thethaothientruong.vn/uploads/contents/gap-bung-bao-lan-1-ngay.jpg',N'Bắt đầu với tư thế nằm ngửa thoải mái trên sàn nhà hoặc thảm tập Yoga, hai chân co tạo thành 1 góc 90 độ và bàn chân đặt trên sàn. Lưu ý, đặt nhẹ các ngón tay đằng sau gáy hoặc hai bên tai và nhớ không dùng lực tay để kéo căng vùng cổ khi gập bụng.',3,10)
 insert into BaiTap values(2,N'Hít đất','http://media.hanoitv.vn/files/hoangyen/2020-06-10/tac-dung-cua-hit-dat-2.jpg',N'Vào tư thế hít đất với 2 tay chống trên sàn, vị trí ngang ngay ngực, cánh tay thẳng ngay dưới vai, mũi bàn tay hướng tới trước. Trụ trên 2 tay và 2 đầu gối. Từ từ hạ thấp thân người xuống, đến khi ngực gần chạm sàn, khuỷu tay tạo thành góc 45 độ, giữ 1 giây. Đẩy người lên trở lại vị trí ban đầu.',3,10)
 insert into BaiTap values(2,N'Squat','https://wikiphunu.com.vn/wp-content/uploads/2020/09/Tap-Squat-giam-mo-bung-hieu-qua-can-luu-y-toi-dong-tac-va-tu-the-thuc-hien.jpg',N'Đứng thẳng, 2 tay đặt sau đầu. Hạ người xuống về tư thế Squat sau đó chuyển 1 chân về tư thế quỳ và tiếp theo chân kia. Trở về tư thế Squat và đúng lên như cũ.',3,15);
 insert into BaiTap values(1,N'Gập bụng chạm mũi chân','http://cdn.thehinh.com/2016/08/Single-Leg-Toe-Touches.jpg',N'Đầu tiên nằm ngửa trên sàn, giở chân trái lên cao vuông góc sàn. Kéo người lên đồng thời đưa tay phải chạm vào mũi chân trái. Trở lại vị trí ban đầu và thực hiện lại thêm 10-15 giây sau đó đổi chân. Để dễ hơn, bạn có thể chỉ cần co gối lên 90 độ và thực hiện chạm vào đầu gối cũng được nha.',4,5)
 insert into BaiTap values(2,N'Động tác leo núi trên bộ','https://www.thethaothientruong.vn/uploads/contents/mountain-climbers.jpg',N'Đầu tiên các bạn hãy vào tư thế chống đẩy với tay dưới vai và lưng thẳng. Kéo gối trái lên ngay sau cùi chỏ tay trái. Và đưa trở lại vị trí cũ. Kéo gối phải lên ngay sau đó và cũng đưa về vị trí cũ. Thực hiện xen kẽ 2 chân càng nhanh càng tốt.',5,10)
 insert into BaiTap values(1,N'Hít đất chéo tay','http://cdn.thehinh.com/2016/08/Forearm-Crossover-Pushup.jpg',N'Vào tư thế hít đất với 2 bàn tay bắt chéo nhau (Hình A), 2 chân duỗi thẳng và mở rộng bằng vai. Hạ thấp người xuống đến khi 2 khuỷu tay đặt lên sàn. (Hình B). Trở lại vị trí cũ và thực hiện lại động tác.',3,5)
 insert into BaiTap values(1,N'Chùng chân và đá cao','http://cdn.thehinh.com/2016/08/Reverse-lunge-Kick.jpg',N'Đầu tiên các bạn đứng thẳng. 2 tay giữ trước ngực cách ngực 1 khoảng như tư thế thủ trong tập võ. Bước chân phải ra sau 1 bước dài, chùng gối trái xuống cho đùi song song sàn. Đứng thẳng lên đồng thời kéo chân phải lên đá tới trước càng cao càng tốt. Bước chân phải về sau và thực hiện thêm 15 giây nữa.',3,15)
 insert into BaiTap values(1,N'Plank','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTNH4d_FcZ4S0kAtfUNb9vvq3oVbAbsu9bwvQ&usqp=CAU',N'Mông, lưng và vai tạo thành một đường thẳng thay vì nâng cao mông lên. Tăng lực vào cơ bụng để giảm đau nhức và sức nâng đỡ cho cột sống Duy trì tuần hoàn hô hấp trong quá trình tập luyện tránh nín thở sẽ không tốt cho tim Khi chống khuỷu tay xuống sàn cần mở rộng khoảng cách vừa đủ để giữ thăng bằng.',4,10)
 insert into BaiTap values(1,N'Nằm nhấc chân','https://lykos.vn/web/wp-content/uploads/2017/04/bai-tap-cardio-giam-can-tai-nha-legs-raise.jpg',N'Bắt đầu ở tư thế nằm ngửa trên sàn, 2 chân duỗi thẳng và đặt sát vào nhau. 2 tay đặt song song với cơ thể, lòng bàn tay úp xuống. Từ từ nâng 2 chân khỏi mật đấu sao cho vuông góc với mặt sàn. Sau đó từ từ hạ 2 chân xuống nhưng không chạm sàn. Tiếp tục lặp lại động tác nhanh nhất có thể.',5,15)
 insert into BaiTap values(2,N'Chạy bộ','https://images.elipsport.vn/anh-seo-tin-tuc/2020/09/22/10-bai-tap-giam-can-nhanh-nhat-dua-tren-nghien-cuu-6.jpg',N'Chạy bộ là một cách tốt nhất và đơn giản nhất để đốt cháy calo. Và đặc biệt, chạy nước rút còn đốt cháy calo nhanh hơn. Trong một nghiên cứu năm 2012, Paul Williams, thuộc Phòng thí nghiệm Quốc gia Lawrence Berkeley, phát hiện ra rằng, những người chạy bộ gầy và nhẹ hơn so với những người không chạy bộ mà theo đuổi những hình thức luyện tập khác. Vô số phụ nữ và nam giới đã giảm được cân nặng nhờ sự hỗ trợ của hình thức tập thể dục đơn giản này.',3,5)
 insert into BaiTap values(2,N'Nhảy dây','https://images.elipsport.vn/anh-seo-tin-tuc/2020/09/22/10-bai-tap-giam-can-nhanh-nhat-dua-tren-nghien-cuu-2.jpg',N'Nhảy dây là một bài tập toàn thân. Nó kích hoạt cơ mông của bạn để giúp bạn nhảy lên từ mặt đất. Và các nhóm cơ cốt lõi của bạn tham gia luyện tập để giữ bạn đứng thẳng và ổn định khi bạn tiếp đất trở lại. Nhảy dây cũng bao gồm các chuyển động của cánh tay và vai. Vì vậy, cũng giúp phần thân trên trở nên săn chắc. Nhảy dây còn giúp bạn tăng cường khả năng cân bằng và phối hợp. Nhờ đó, không chỉ giúp bạn giảm cân mà còn tốt cho sức khỏe của tim và phổi của bạn.',5,20)
 select * from ThucDon