import CandidatesTable from "./components/CandidatesTable";
import { candidateRoute } from "../../services";
import { useEffect, useState } from "react";
import { Candidate } from "./types";
import { ResultDashboardStyles } from "./styles";

export const ResultDashboard = () => {
  const [candidates, setCandidates] = useState<Candidate[]>([]);

  useEffect(() => {
    candidateRoute.get("/").then((response) => setCandidates(response.data));
  }, []);

  return (
    <>
      <ResultDashboardStyles />
      <CandidatesTable candidates={candidates} />
    </>
  );
};
