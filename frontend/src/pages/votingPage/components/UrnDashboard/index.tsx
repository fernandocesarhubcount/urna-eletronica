import { useState, useEffect } from "react";
import { toast } from "react-toastify";
import { candidateRoute, votesRoute } from "../../../../services";
import { Candidate } from "../../../resultsDashboard/types";
import { UrnDashboardStyle } from "./styles";

export function UrnDashboard() {
  const [value, setValue] = useState<number[]>([]);
  const [subTitle, setSubTitle] = useState("");
  const [candidateInfos, setCandidateInfos] = useState<Candidate[]>([]);
  const [candidates, setCandidates] = useState<Candidate[]>([]);

  useEffect(() => {
    candidateRoute.get("/").then((response) => setCandidates(response.data));
  }, []);

  async function handleRegisterNewVote() {
    await votesRoute.post("/register", voteData);

    toast.success("Voto computado.");
    window.location.reload();
  }

  let voteData = {
    candidateSubTitle: parseInt(subTitle),
  };

  useEffect(() => {
    function setSubTitleValue() {
      setSubTitle(value.join(""));
    }

    function getCandidate() {
      const filteredCandidate = candidates.filter(
        (candidate: Candidate) => candidate.subTitle === Number(subTitle)
      );

      setCandidateInfos(filteredCandidate);
    }

    setSubTitleValue();
    getCandidate();
  }, [value, candidates, subTitle]);

  console.log(candidateInfos);

  return (
    <UrnDashboardStyle>
      {!!candidateInfos.length && (
        <div className="candidateInfos">
          <h2>Candidato:</h2>
          <h2>{candidateInfos[0].fullName}</h2>
          <h2>Vice:</h2>
          <h2>{candidateInfos[0].viceFullName}</h2>
          <h2>Legenda:</h2>
          <h2>{candidateInfos[0].subTitle}</h2>
        </div>
      )}
      <input type="text" value={subTitle} readOnly />
      <div className="buttons">
        <button
          type="button"
          onClick={() => setValue((value: any) => [...value, 1])}
        >
          1
        </button>
        <button
          type="button"
          onClick={() => setValue((value: any) => [...value, 2])}
        >
          2
        </button>
        <button
          type="button"
          onClick={() => setValue((value: any) => [...value, 3])}
        >
          3
        </button>
      </div>
      <div className="buttons">
        <button
          type="button"
          onClick={() => setValue((value: any) => [...value, 4])}
        >
          4
        </button>
        <button
          type="button"
          onClick={() => setValue((value: any) => [...value, 5])}
        >
          5
        </button>
        <button
          type="button"
          onClick={() => setValue((value: any) => [...value, 6])}
        >
          6
        </button>
      </div>
      <div className="buttons">
        <button
          type="button"
          onClick={() => setValue((value: any) => [...value, 7])}
        >
          7
        </button>
        <button
          type="button"
          onClick={() => setValue((value: any) => [...value, 8])}
        >
          8
        </button>
        <button
          type="button"
          onClick={() => setValue((value: any) => [...value, 9])}
        >
          9
        </button>
      </div>
      <div className="zeroButton">
        <button
          type="button"
          onClick={() => setValue((value: any) => [...value, 0])}
        >
          0
        </button>
      </div>
      <div className="optionButtons">
        <button
          type="submit"
          className="voteButton"
          onClick={handleRegisterNewVote}
        >
          Votar
        </button>
        <button
          type="submit"
          className="undoButton"
          onClick={() => {
            setSubTitle("");
            for (let i = value.length; i > 0; i--) {
              value.pop();
            }
          }}
        >
          Corrigir
        </button>
      </div>
    </UrnDashboardStyle>
  );
}
