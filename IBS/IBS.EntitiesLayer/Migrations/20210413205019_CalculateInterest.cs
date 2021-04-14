using Microsoft.EntityFrameworkCore.Migrations;

namespace IBS.EntitiesLayer.Migrations
{
    public partial class CalculateInterest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create proc CalculateInterest
                                @accountNumber varchar(15), @interestRate int
                                as
                                begin
                                declare @interestAmount money
                                set @interestAmount = (select InterestAmount from Accounts where AccountNumber=@accountNumber)
						                                + (@interestRate / 100) * (select AvailableBalance from Accounts where AccountNumber=@accountNumber);
                                update Accounts set InterestAmount=@interestAmount where AccountNumber = @accountNumber;
                                end";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
