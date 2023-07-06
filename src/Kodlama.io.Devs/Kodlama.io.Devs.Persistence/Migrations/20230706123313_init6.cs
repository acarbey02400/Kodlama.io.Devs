using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
           




            migrationBuilder.CreateIndex(
                name: "IX_GithubProfiles_UserId",
                table: "GithubProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PLTechnologies_ProgramingLanguageId",
                table: "PLTechnologies",
                column: "ProgramingLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GithubProfiles");

            migrationBuilder.DropTable(
                name: "PLTechnologies");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramingLanguage",
                table: "ProgramingLanguage");

            migrationBuilder.RenameTable(
                name: "ProgramingLanguage",
                newName: "ProgramingLanguages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramingLanguages",
                table: "ProgramingLanguages",
                column: "Id");
        }
    }
}
