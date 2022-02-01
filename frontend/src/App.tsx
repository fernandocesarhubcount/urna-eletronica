import { Router, RouteComponentProps } from "@reach/router";
import { ResultDashboard } from "./pages/resultsDashboard";
import { VotingPage } from "./pages/votingPage";
import { GlobalStyle } from "./styles/global";

function App() {
  return (
    <>
      <GlobalStyle />
      <Router>
        <RouterPage path="/deashboard" pageComponent={<ResultDashboard />} />
        <RouterPage path="/urn" pageComponent={<VotingPage />} />
      </Router>
    </>
  );
}

const RouterPage = (
  props: { pageComponent: JSX.Element } & RouteComponentProps
) => props.pageComponent;

export default App;
