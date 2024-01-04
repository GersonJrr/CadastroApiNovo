function editar() {
    debugger
    const body = {
        pessoaId : document.getElementById("pessoaId").value,
        primeiroNome: document.getElementById("primeiroNome").value,
        nomeMeio:  document.getElementById("primeiroNome").value,
        ultimoNome:  document.getElementById("primeiroNome").value,
        CPF: document.getElementById("primeiroNome").value,
    };

    fetch(`https://localhost:7091/api/Pessoa/UpdateByid/${pessoaId}?novoNome=${primeiroNome}&NNomeMeio=${nomeMeio}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(`Erro na requisição: ${response.status}`);
        }
        return response.json();
    })
    .then(data => {
        console.log('Registro atualizado com sucesso:', data);
    })
    .catch(error => {
        console.error('Erro durante a atualização:', error);
    });
}





