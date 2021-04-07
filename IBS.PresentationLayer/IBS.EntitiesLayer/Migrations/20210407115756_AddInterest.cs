using Microsoft.EntityFrameworkCore.Migrations;

namespace IBS.EntitiesLayer.Migrations
{
    public partial class AddInterest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create proc AddInterest
                                @accountNumber varchar(15)
                                as
                                begin
                                declare @balance money
                                declare @interest money = (select InterestAmount from Accounts where AccountNumber=@accountNumber)
                                set @balance=(select AvailableBalance from Accounts where AccountNumber=@accountNumber)+@interest
                                Update Accounts set AvailableBalance = @balance where AccountNumber = @accountNumber
                                Update Accounts set InterestAmount=0 where AccountNumber = @accountNumber
                                insert into Transactions values(GETDATE(),'InterestAmount',@accountNumber,@interest,'interest added',@accountNumber)
                                select * from Transactions where TransactionID = SCOPE_IDENTITY()
                                end";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
