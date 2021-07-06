const urlCandidate = 'https://localhost:44362/api/Candidates';


function checkTicketLength() {
    var length = document.getElementById("ticket").value.length
    if (length > 2) {
        var resultValue = document.getElementById("ticket").value.slice(0, 2);
        document.getElementById("ticket").value = resultValue;
    }
}

function checkEmptiness(id) {
    var length = document.getElementById(id).value.length
    console.log(length)
    if (length < 1) {
        document.getElementById(id).style.borderColor = 'red'
    }
    else {
        document.getElementById(id).style.borderColor = ''
    }
}

function CreateCandidate() {

    const item = {
        candidateName: document.getElementById("candidateName").value,
        viceName: document.getElementById("viceName").value,
        registryDate: document.getElementById("registryDate").value,
        ticket: document.getElementById("ticket").value
    };

    fetch(urlCandidate, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    }).then(function (response) {
        console.log(response.status);
        if (!response.ok) {
            modal.style.display = "block"
            modalMessage.innerText = "Inválido, Verifique os campos."
            throw new Error("HTTP status " + response.status);
        }
        modalMessage.innerText = "Sucesso."
        modal.style.display = "block"
    })
        .catch(error => console.error('Não foi possível cadastrar o candidato.', error));
}

function DeleteCandidate(id) {

    fetch(`${urlCandidate}/${id}`, {
        method: 'DELETE'
    })
        .catch(error => console.error('Unable to delete item.', error));
}

function GetTodayDate() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0');
    var yyyy = today.getFullYear();

    return today = yyyy + '-' + mm + '-' + dd;
}

var modal = document.getElementById("myModal");

var modalMessage = document.getElementById("modalMessage");

var span = document.getElementsByClassName("close")[0];

span.onclick = function () {
    modal.style.display = "none";
    window.location.reload(true)
}

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
        window.location.reload(true)
    }
}



const uriCandidate = 'api/Candidates';
const uriVotes = 'api/Votes';

//Support Variables
let candidateId;

function SetValue(ClickedValue) {
    if (!document.getElementById("number1").value != "") {
        document.getElementById("number1").value = ClickedValue;
    }
    else if (!document.getElementById("number2").value != "") {
        document.getElementById("number2").value = ClickedValue;
        SearchCandidate();
    }
    else {
        document.getElementById("numberButton").disabled = true;
        document.getElementById("numberButton1").disabled = true;
        document.getElementById("numberButton2").disabled = true;
        document.getElementById("numberButton3").disabled = true;
        document.getElementById("numberButton4").disabled = true;
        document.getElementById("numberButton5").disabled = true;
        document.getElementById("numberButton6").disabled = true;
        document.getElementById("numberButton7").disabled = true;
        document.getElementById("numberButton8").disabled = true;
        document.getElementById("numberButton9").disabled = true;
    }
}

function Clear() {
    document.getElementById("number1").value = "";
    document.getElementById("number2").value = "";
    document.getElementById("candidateName").innerText = "";
    document.getElementById("candidateVice").innerText = "";
    document.getElementById("confirmButton").disabled = true;

    document.getElementById("numberButton").disabled = false;
    document.getElementById("numberButton1").disabled = false;
    document.getElementById("numberButton2").disabled = false;
    document.getElementById("numberButton3").disabled = false;
    document.getElementById("numberButton4").disabled = false;
    document.getElementById("numberButton5").disabled = false;
    document.getElementById("numberButton6").disabled = false;
    document.getElementById("numberButton7").disabled = false;
    document.getElementById("numberButton8").disabled = false;
    document.getElementById("numberButton9").disabled = false;
}

function WhiteVote() {
    document.getElementById("number1").value = "0";
    document.getElementById("number2").value = "0";
    SearchCandidate();
}

function Vote() {
    const item = {
        registryDate: GetTodayDate(),
        candidateId: candidateId
    };

    fetch(uriVotes, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(VoteSuccess())
        .catch(error => console.error('Não foi possível efetuar o voto.', error));
}

function VoteSuccess() {
    modal.style.display = "block"
}

function SearchCandidate() {

    var ticket = document.getElementById("number1").value + document.getElementById("number2").value;

    if (ticket == '00') { ticket = 0 }

    fetch(uriCandidate)
        .then(response => response.json())
        .then(data => _displayCandidate(data, ticket))
        .catch(error => console.error('Não foi possível consultar os candidatos.', error));

}

function GetTodayDate() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0');
    var yyyy = today.getFullYear();

    return today = yyyy + '-' + mm + '-' + dd;
}

function _displayCandidate(data, ticket) {
    data.forEach(item => {
        if (item["ticket"] == ticket) {
            candidateId = item["candidateId"]
            document.getElementById("candidateName").innerText = "Nome do Candidato: " + item["candidateName"];
            document.getElementById("candidateVice").innerText = "Nome do Vice-Candidato: " + item["viceName"];
            document.getElementById("confirmButton").disabled = false;
        }
    });
}

var modal = document.getElementById("myModal");
var span = document.getElementsByClassName("close")[0];

span.onclick = function () {
    modal.style.display = "none";
    window.location.reload(true)
}

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
        window.location.reload(true)
    }
}

var names = [];
var votes = [];

fetch(urlCandidate)
    .then(response => response.json())
    .then(data => plotGraph(data))
    .catch(error => console.error('Não foi possível consultar os candidatos.', error));


function plotGraph(data) {

    data.sort((a, b) => parseInt(b["votes"].length) - parseInt(a["votes"].length));

    data.forEach(item => {
        names.push(item["candidateName"]);
        votes.push(item["votes"].length);
    });

    var ctx = document.getElementById("myChart");
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: names,
            datasets: [
                {
                    data: votes,
                    label: "Votos"
                }
            ]
        }
    });
}