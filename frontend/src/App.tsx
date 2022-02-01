import { Router, RouteComponentProps } from "@reach/router";
import { ToastContainer } from "react-toastify";
import { RegisterCandidatePage } from "./pages/registerCandidatePage";
import { ResultDashboard } from "./pages/resultsDashboard";
import { VotingPage } from "./pages/votingPage";
import { GlobalStyle } from "./styles/global";
import "react-toastify/dist/ReactToastify.css";

function App() {
  return (
    <>
      <ToastContainer autoClose={3000} />
      <GlobalStyle />
      <Router>
        <RouterPage path="/dashboard" pageComponent={<ResultDashboard />} />
        <RouterPage path="/" pageComponent={<VotingPage />} />
        <RouterPage
          path="/createCandidate"
          pageComponent={<RegisterCandidatePage />}
        />
      </Router>
    </>
  );
}

const RouterPage = (
  props: { pageComponent: JSX.Element } & RouteComponentProps
) => props.pageComponent;

export default App;
