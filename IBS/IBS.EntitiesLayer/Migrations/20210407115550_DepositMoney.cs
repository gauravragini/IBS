using Microsoft.EntityFrameworkCore.Migrations;

namespace IBS.EntitiesLayer.Migrations
{
    public partial class DepositMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create proc DepositMoney
                                @accountNumber varchar(15),@amount money
                                as
                                begin
                                declare @balance money
                                set @balance=(select AvailableBalance from Accounts where AccountNumber=@accountNumber)+@amount
                                Update Accounts set AvailableBalance= @balance where AccountNumber=@accno
                                insert into Transactions values(GETDATE(),'self',@accountNumber,@amount,'deposited',@accountNumber)
                                select * from Transactions where TransactionID = SCOPE_IDENTITY()
                                end";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
