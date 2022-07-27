import React, { useState } from "react";

import {Link, useHistory} from 'react-router-dom'

import {FiArrowLeft} from 'react-icons/fi'
import api from '../../services/api'
import './styles.css'


export default function NewCandidate(){

    const [fullName,setfullName] = useState('');
    const [viceName,setviceName] = useState('');
    const [legend,setlegend] = useState(0); 
    const [registerDate, setregisterDate] = useState('');
    
    const history = useHistory();

    async function createNewCandidate(e){
       
        e.preventDefault();

        const data = {
            fullName,
            viceName,
            legend,
            registerDate,
          }

        try{
            await api.post("/candidate",data); 
            alert('Novo candidato cadastrado com sucesso');  
        }
        catch(err)
        {
            alert(err,'Error Try Again');
        }
        history.push('/candidate');
        console.log()
    }
    return (
        <div className="new-book-container">
            <div className="content">
                <section className="form">
                    <h1>Adicione um novo candidato</h1>
                    <p>Digite as informações do candidato e clique em adicionar</p>
                    <Link className="back-link" to="/votes">
                        <FiArrowLeft size = {16} color = "#251fc5"/>
                        Votes
                    </Link>

                </section>

                <form onSubmit={createNewCandidate}>
                    <input 
                        placeholder = "Nome  completo"
                        value = {fullName}
                        onChange={e=> setfullName(e.target.value)}
                    />
                    <input 
                        placeholder="Nome do vice" 
                        value = {viceName}
                        onChange={e=> setviceName(e.target.value)}    
                    /> 
                    <input 
                        type ="date"
                        value = {registerDate}
                        onChange={e=> setregisterDate(e.target.value)}
                    />
                    <input 
                        placeholder="Numero Legenda"  type="value"
                        value = { legend }
                        onChange={e=>setlegend(e.target.value)}
                    /> 
                    <button className="button" type="submit">Add</button>
                </form>
            </div>
        </div>
    );
}