using Microsoft.EntityFrameworkCore.Migrations;

namespace IBS.EntitiesLayer.Migrations
{
    public partial class WithdrawInterest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create proc WithdrawInterest
                                @accountNumber varchar(15)
                                as
                                begin
                                declare @interest money = (select InterestAmount from Accounts where AccountNumber=@accountNumber)
                                Update Accounts set InterestAmount=0 where AccountNumber=@accountNumber
                                insert into Transactions values(GETDATE(),'InterestAmount','self',@interest,' interest withdrawn',@accountNumber)
                                select * from Transactions where TransactionID = SCOPE_IDENTITY()
                                end";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
