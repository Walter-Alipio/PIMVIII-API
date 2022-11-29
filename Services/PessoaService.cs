using System.Text.RegularExpressions;
using AutoMapper;
using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Data.DTOs.PessoaDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;
using FluentResults;

namespace Cadastro_Teleatendimento.Services
{
  public class PessoaService : IPessoaService
  {
    private IPessoaTelefone<Pessoa> _pessoaDAO;
    private IMapper _mapper;

    public PessoaService(IPessoaTelefone<Pessoa> pessoaDAO, IMapper mapper)
    {
      _mapper = mapper;
      _pessoaDAO = pessoaDAO;
    }

    //Get
    public ReadPessoaDto? BuscaCpf(Int64 cpf)
    {
      Pessoa? pessoa = _pessoaDAO.BuscaPorCpf(cpf);
      if (pessoa == null)
        return null;
      ReadPessoaDto readDto = _mapper.Map<ReadPessoaDto>(pessoa);
      while (readDto.Cpf!.Length < 11)
      {
        readDto.Cpf = "0" + readDto.Cpf;
      }

      return readDto;
    }
    //não implementado
    public ReadPessoaDto? BuscaPorId(int id)
    {
      throw new NotImplementedException();
    }
    //Post
    public ReadPessoaDto? CadastraPessoa(CreatePessoaDto pessoaDto)
    {

      if (String.IsNullOrEmpty(pessoaDto.Nome) || String.IsNullOrEmpty(pessoaDto.Cpf) || pessoaDto.Fk_Endereco == 0 || pessoaDto.Telefones == null)
        return null;
      Pessoa? pessoa = _mapper.Map<Pessoa>(pessoaDto);

      List<int> telefones = pessoaDto.Telefones;

      var resultado = _pessoaDAO.Insira(pessoa);
      if (!resultado)
        return null;

      var newPessoa = _pessoaDAO.BuscaPorCpf(pessoa.Cpf);
      foreach (var telefone in telefones)
      {
        var resolvido = _pessoaDAO.CadastraTelefones(newPessoa!.Id_Pessoa, telefone);

        if (!resolvido) break;
      }
      newPessoa = _pessoaDAO.BuscaPorCpf(pessoa.Cpf);
      return _mapper.Map<ReadPessoaDto>(newPessoa);
    }

    //Put
    public Result AlteraDadosPessoa(UpdatePessoaDto pessoaDto)
    {

      if (pessoaDto.Telefones == null)
        return Result.Fail("Dado obrigatório.");

      List<int> telefones = pessoaDto.Telefones;

      Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);
      var resultado = _pessoaDAO.Altere(pessoa);
      if (!resultado)
        return Result.Fail("Falha ao alterar cadastro");

      return Result.Ok();
    }

    //Delete
    public Result ExcluiPessoa(Int64 Cpf)
    {
      var pessoa = _pessoaDAO.BuscaPorCpf(Cpf);
      if (pessoa == null)
        return Result.Fail("Item não encontrado.");

      var resultado = _pessoaDAO.Exclua(pessoa.Id_Pessoa);

      return Result.Ok();
    }

    public Result ValidaCpf(string cpf)
    {
      Regex pattern = new Regex(@"\d{9}");

      if (!pattern.IsMatch(cpf))
        return Result.Fail("Formato de cpf incorreto.");

      return Result.Ok();
    }
  }
}