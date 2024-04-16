// Função para ocultar ou exibir os campos de acordo com o valor selecionado
function toggleInputs() {
  const selectValue = select.value;
  console.log(selectValue);

  if (selectValue === "Serviço") {
    divServ.style.display = "block";
    divProd.style.display = "none";
    console.log(divProd.style.display);
    console.log(divServ.style.display);
  } else if (selectValue === "Produto") {
    divServ.style.display = "none";
    divProd.style.display = "block";
    console.log(divProd.style.display);
    console.log(divServ.style.display);
  }
  console.log(divProd.style.display);
  console.log(divServ.style.display);
}

//Criar preço da Ordem de Compra

function createPrice() {
  // Verifique se há valores válidos antes de calcular
  if (!isNaN(parseFloat(quantidade.value)) && !isNaN(parseFloat(valor.value))) {
    // Calcula o valor total multiplicando a quantidade pelo valor unitário
    valortotal.value = (
      parseFloat(quantidade.value) * parseFloat(valor.value)
    ).toFixed(2); // Limita a duas casas decimais
    console.log(valortotal.value);
    console.log(quantidade.value);
    console.log(valor.value);
  } else {
    console.log(
      "Por favor, insira valores numéricos válidos para quantidade e valor."
    );
  }
}

function getValueSelect() {
  document.getElementById("selectValue").value = this.value;
  console.log(this.value);
  console.log(document.getElementById("selectPI"));
  console.log(document.getElementById("selectValue").value);
}

function configurarCampoData() {
  var hoje = new Date().toISOString().split("T")[0]; // Obtém a data atual no formato YYYY-MM-DD
  document.getElementById("dataEntrega").setAttribute("min", hoje); // Define o valor mínimo como a data atual

  // Limita as opções de ano para o ano atual
  var anoAtual = new Date().getFullYear();
  var anoMaximo = anoAtual + "-12-31"; // Último dia do ano atual
  document.getElementById("dataEntrega").setAttribute("max", anoMaximo); // Define o valor máximo como o último dia do ano atual
}

// Seleciona os elementos
const select = document.getElementById("selectPI");
const divServ = document.getElementById("divServ");
const divProd = document.getElementById("divProd");
const quantidade = document.getElementById("quantidade");
const qtdpedida = document.getElementById("qtdpedida");
const valor = document.getElementById("valor");
const valortotal = document.getElementById("valortotal");
const selectPI = document.getElementById("selectPI");

// Executa a função quando a página é carregada
window.addEventListener("load", toggleInputs);
window.addEventListener("load", configurarCampoData);

// Adiciona um ouvinte de evento de mudança ao select
if (select) {
  select.addEventListener("change", toggleInputs);
}

if (quantidade) {
  quantidade.addEventListener("blur", createPrice);
}

if (selectPI) {
  selectPI.addEventListener("change", getValueSelect);
}
