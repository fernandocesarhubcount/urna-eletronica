import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { candidateRoute } from "../../../../services";
import CandidatesTable from "../../../resultsDashboard/components/CandidatesTable";
import { Candidate } from "../../../resultsDashboard/types";
import { DashboardContainer, CreateCandidateButton, Header } from "./styles";

export function RegisterCandidate() {
  const [fullName, setFullName] = useState("");
  const [viceFullName, setViceFullName] = useState("");
  const [subTitle, setSubTitle] = useState<number>();
  const [candidates, setCandidates] = useState<Candidate[]>([]);

  useEffect(() => {
    candidateRoute.get("/").then((response) => setCandidates(response.data));
  }, []);

  async function handleCreateNewCandidate() {
    const data = {
      fullName,
      viceFullName,
      subTitle,
    };

    await candidateRoute.post("/register", data);

    window.location.reload();
  }

  return (
    <>
      <Header>Cadastrar candidato</Header>

      <DashboardContainer>
        <input
          value={fullName}
          onChange={(event) => setFullName(event.target.value)}
          placeholder="Candidato"
        />
        <input
          value={viceFullName}
          onChange={(event) => setViceFullName(event.target.value)}
          placeholder="Vice"
        />
        <input
          value={subTitle}
          onChange={(event) => setSubTitle(parseInt(event.target.value))}
          placeholder="Número do candidato"
        />
      </DashboardContainer>

      <CreateCandidateButton>
        <button onClick={handleCreateNewCandidate}>Criar novo candidato</button>
      </CreateCandidateButton>

      <CandidatesTable candidates={candidates} />
    </>
  );
}
