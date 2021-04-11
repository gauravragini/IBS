using Microsoft.EntityFrameworkCore.Migrations;

namespace IBS.EntitiesLayer.Migrations
{
    public partial class TransferMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create proc TransferMoney
                                @accountNumber varchar(15),@toAccountNumber varchar(15), @amount money
                                as
                                begin
                                declare @tobalance money
                                declare @balance money
                                set @tobalance=(select AvailableBalance from Accounts where AccountNumber=@toAccountNumber)+@amount
                                Update Accounts set AvailableBalance= @tobalance where AccountNumber=@toAccountNumber
                                set @balance=(select AvailableBalance from Accounts where AccountNumber=@accountNumber)-@amount
                                Update Accounts set AvailableBalance= @balance where AccountNumber=@accountNumber
                                insert into Transactions values(GETDATE(),@accountNumber,@toAccountNumber,@amount,'transferred',@accountNumber)
                                select * from Transactions where TransactionID = SCOPE_IDENTITY()
                                end";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
