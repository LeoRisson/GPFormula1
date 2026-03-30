namespace GPFormula1.Api.Dtos.Equipe
{
    public record CriarEquipeDto(
        string Nome,
        string Pais
    );

    public record AtualizarEquipeDto(
        string Nome,
        string Pais
    );
}
