namespace GPFormula1.Api.Dtos.GrandePremio
{
    public record CriarGrandePremioDto(
        string Nome,
        string Local,
        string Circuito,
        DateTime Data,
        int TemporadaId
    );

    public record AtualizarGrandePremioDto(
        string Nome,
        string Local,
        string Circuito,
        DateTime Data,
        int TemporadaId
    );
}
