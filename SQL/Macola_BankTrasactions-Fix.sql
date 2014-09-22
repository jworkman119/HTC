Select *
Into BankTransactions_Backup
From BankTrasactions;


update banktransactions 
set status = 'V'
where (syscreator = 24049) and (syscreated >= '2013-03-11 11:53:04.877') and (syscreated <= '2013-03-11 11:55:04.877');
