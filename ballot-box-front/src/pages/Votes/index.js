import React, {useState, useEffect } from "react";


import './styles.css'
import api from "../../services/api";

export default function Votes()
{
    const [candidatesVotes,setcandidatesVotes] = useState([]);


    useEffect(()=>{
        api.get('/votes').then(response => { 
            setcandidatesVotes(response.data);
        });
    })

    return ( 
        <div className = "vote-container">

            <h1>Ranking de Votos</h1>
                <ul>
                    {candidatesVotes.map(candidate=>(
                    <li>
                        <strong>Posição </strong>
                        <p>{candidatesVotes.indexOf(candidate)+1}</p>
                        <strong>Nome do candidato: </strong>
                        <p>{candidate.candidateResponse.fullName}</p>
                        <strong>Nome do vice: </strong>
                        <p>{candidate.candidateResponse.viceName}</p>
                        <strong>Legenda: </strong>
                        <p>{candidate.candidateResponse.legend}</p>
                        <strong>Número de votos: </strong>
                        <p>{candidate.votesCount}</p>
                    </li>
                    ))}
                   
                </ul>

        </div>
        )
}