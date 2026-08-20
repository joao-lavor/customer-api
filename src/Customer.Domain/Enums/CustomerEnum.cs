using System.ComponentModel;

namespace Customer.Domain.Enums
{
    public enum CustomerEnum
    {
        [Description("É necessário informar o nome do cliente!")]
        CustomerRegistration_InvalidName,

        [Description("Falha ao cadastrar o cliente!")]
        CustomerRegistration_Failed,

        [Description("Cliente cadastrado com sucesso!")]
        CustomerRegistration_Successful,

        [Description("Cliente já cadastrado!")]
        CustomerRegistration_DuplicateCustomer,


        [Description("É necessário informar o nome do cliente!")]
        CustomerUpdate_InvalidName,

        [Description("É necessário informar um CPF válido!")]
        CustomerUpdate_InvalidCpf,

        [Description("Cliente atualizado com sucesso!")]
        CustomerUpdate_Successful,

        [Description("Falha ao tentar atualizar o cliente!")]
        CustomerUpdate_Failed,

        [Description("Cliente inválido ou inexistente!")]
        Customer_NotFound,

        [Description("Ja existe outro cliente cadastrado com esse CPF, verifique!")]
        CustomerUpdate_CPF_AlreadyRegistered,

        [Description("Cliente excluido com sucesso!")]
        CustomerDelete_Sucessful,

        [Description("Falha ao tentar excluir cliente!")]
        CustomerDelete_Failed,

        [Description("É necessário informar um CPF válido!")]
        Customer_NotEmpty,

        [Description("É necessário informar um CPF válido!")]
        Customer_InvalidCpf,



    }
}
