import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import IconButton from "@mui/material/IconButton";
import DeleteIcon from "@mui/icons-material/Delete";
import { Candidate } from "../../types";
import { TableContainerStyle } from "./styles";
import { candidateRoute } from "../../../../services";

interface CandidatesTableProps {
  candidates: Candidate[];
}

export default function CandidatesTable({ candidates }: CandidatesTableProps) {
  return (
    <TableContainerStyle>
      <Table aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell align="center">Candidato</TableCell>
            <TableCell align="center">Vice</TableCell>
            <TableCell align="center">Legenda</TableCell>
            <TableCell align="center">Número de votos</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {candidates.map((candidate) => (
            <TableRow key={candidate.subTitle}>
              <TableCell component="th" scope="row" align="center">
                {candidate.fullName}
              </TableCell>
              <TableCell align="center">{candidate.viceFullName}</TableCell>
              <TableCell align="center">{candidate.subTitle}</TableCell>
              <TableCell align="center">{candidate.votes.length}</TableCell>
              <IconButton
                aria-label="delete"
                onClick={() => {
                  candidateRoute.delete(
                    `/delete?candidateSubTitle=${candidate.subTitle}`
                  );
                }}
              >
                <DeleteIcon />
              </IconButton>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainerStyle>
  );
}
