import styled from "styled-components";
import { TableContainer } from "@mui/material";

export const TableContainerStyle = styled(TableContainer)`
  display: flex;
  align-items: center;
  justify-content: center;

  Table {
    margin-top: 6rem;
    width: 50%;
    background: var(--shape);
    border-radius: 1rem;

    th {
      text-align: left;
      border-radius: 1rem;
    }

    tr {
      text-align: left;

      td {
        text-align: left;
      }
    }
  }
`;
