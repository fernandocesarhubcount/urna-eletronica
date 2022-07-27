import React, {useState, useEffect } from "react";

import './styles.css'
import api from "../../services/api";

export default function Vote()
{
    const [numValue, setnumValue]  = useState(0);
    const [numValue2, setnumValue2]  = useState(0);
    const [voted, setVoted]  = useState(
            {candidateId: 0,
            fullName: "string",
            viceName: "string",
            legend: 0,
            registerDate: "2022-07-27T03:44:34.417Z"});

    const [candidates,setCandidates] = useState([]);
    const [candidateLegend,setCandidateLegend] = useState(0);
   
    useEffect(()=>{
        api.get('/candidate').then(response => { 
            setCandidates(response.data);
        });
        setCandidateLegend(Number('' + numValue + numValue2))
        var candidate = candidates.find(candidate => candidate.legend == candidateLegend)
        setVoted(candidate);
    })

    async function createNewVote(e){
       
        e.preventDefault();
        var candidateId= voted.candidateId;
        var today= new Date().toLocaleString('en-US', { timeZone: 'UTC' });
        const data = {
            candidateId,
            today
        }
        console.log(data);

        try{
            await api.post("/vote",data); 
            alert('Voto cadastrado com sucesso');  
        }
        catch(err)
        {
            alert(err,'Error Try Again');
        }
        console.log()
    }
   
    function handleValue(value) {
        
       if(numValue==0)
       {
        setnumValue(value)
       }
       else
       if(numValue2==0)
       {
        setnumValue2(value)
       }
       
    }
    function fixValue(value) {
         setnumValue2(value);
         setnumValue(value);
     }
   return (

    <div class="container">
    <div class="branco">
        <div class="cinzaClaro">
            <p>{}</p>
            <form action="">
            <input 
                    type="number"
                    value = {numValue}
                    onChange = {event => setnumValue(Number(event.target.value))}
                />
            <input 
                    type="number"
                    value = {numValue2}
                    onChange = {event => setnumValue2(Number(event.target.value))}
            />
            </form>
            <p>{""}</p>
        </div>
        <div class="cinzaEscuro"> 
        </div>
        <div class="preto">
        <button class="bnt click"
                        type = "button"
                        onClick = {()=>{handleValue(1)}}
                        >1
        </button> 
        <button class="bnt click"
                        type = "button"
                        onClick = {()=>{handleValue(2)}}
                        >2
        </button> 
        <button class="bnt click"
                        type = "button"
                        onClick = {()=>{handleValue(3)}}
                        >3
        </button> 
        <button class="bnt click"
                        type = "button"
                        onClick = {()=>{handleValue(4)}}
                        >4
        </button> 
        <button class="bnt click"
                        type = "button"
                        onClick = {()=>{handleValue(5)}}
                        >5
        </button> 
        <button class="bnt click"
                        type = "button"
                        onClick = {()=>{handleValue(6)}}
                        >6
        </button> 
        <button class="bnt click"
                        type = "button"
                        onClick = {()=>{handleValue(7)}}
                        >7
        </button> 
        <button class="bnt click"
                        type = "button"
                        onClick = {()=>{handleValue(8)}}
                        >8
        </button> 
        <button class="bnt click"
                        type = "button"
                        onClick = {()=>{handleValue(9)}}
                        >9
        </button> 
        <button class="bnt click"
                        type = "button"
                        onClick = {()=>{handleValue(0)}}
                        >0
        </button> 
            <div class="teclado2">
                <button class="branco  click">BRANCO</button>
                <button class="laranja  click" onClick = {()=>{fixValue(0)}}>CORRIGE</button>
                <button class="verde" onClick={createNewVote}>CONFIRMA</button>
            </div>
        </div>
    </div>
</div>

   );
}