namespace GPFormula1.Api.Dtos.Piloto
{
    public record PilotoDto(int Id, string Nome, string Nacionalidade, int NumeroCarro, int EquipeId);

    public record CriarPilotoDto(string Nome, string Nacionalidade, int NumeroCarro, int EquipeId);
    public record AtualizarPilotoDto(string Nome, string Nacionalidade, int NumeroCarro, int EquipeId);

}