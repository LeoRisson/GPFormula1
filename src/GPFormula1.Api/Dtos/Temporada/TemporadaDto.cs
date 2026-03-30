namespace GPFormula1.Api.Dtos.Temporada
{
    public record CriarTemporadaDto(
        int Ano,
        int? CampeaoPilotosId,
        int? CampeaoConstrutoresId
    );

    public record AtualizarTemporadaDto(
        int Ano,
        int? CampeaoPilotosId,
        int? CampeaoConstrutoresId
    );
}
