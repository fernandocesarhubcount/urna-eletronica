import axios from "axios";

export const candidateRoute = axios.create({
  baseURL: "https://localhost:5001/candidate",
});

export const votesRoute = axios.create({
  baseURL: "https://localhost:5001/vote",
});
