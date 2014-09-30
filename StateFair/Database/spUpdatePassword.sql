create procedure htcStateFair.updatePassword (IN User VARCHAR(25),IN PassWord VARCHAR(100))
Begin


Update Users
Set Users.Pwd = PassWord
where Users.UserName = User;

End
