using Microsoft.EntityFrameworkCore.Migrations;

namespace IBS.EntitiesLayer.Migrations
{
    public partial class WithdrawMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create proc WithdrawMoney
                                @accountNumber varchar(15),@amount money
                                as
                                begin
                                declare @balance money
                                set @balance=(select AvailableBalance from Accounts where AccountNumber=@accountNumber)-@amount
                                Update Accounts set AvailableBalance= @balance where AccountNumber=@accountNumber
                                insert into Transactions values(GETDATE(),@accountNumber,'self',@amount,'withdrawn',@accountNumber)
                                select * from Transactions where TransactionID = SCOPE_IDENTITY()
                                end";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
