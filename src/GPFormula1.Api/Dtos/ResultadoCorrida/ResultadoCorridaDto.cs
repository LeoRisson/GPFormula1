namespace GPFormula1.Api.Dtos.ResultadoCorrida
{
    public record CriarResultadoCorridaDto(
        int PilotoId,
        int GPId,
        int? Posicao,
        string? Tempo,
        int? Voltas,
        string? Status
    );

    public record AtualizarResultadoCorridaDto(
        int PilotoId,
        int GPId,
        int? Posicao,
        string? Tempo,
        int? Voltas,
        string? Status
    );
}
