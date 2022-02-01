import styled from "styled-components";

export const Header = styled.header`
  padding: 2rem;
  display: flex;
  flex-direction: row;
  justify-content: center;
  font-family: Roboto;
  font-size: 2rem;
  color: #e7e9ee;
`;

export const CreateCandidateButton = styled.div`
  display: flex;
  justify-content: center;
  margin-top: 1rem;

  button {
    font-size: 1rem;
    color: #fff;
    background: #0cff57;
    border: 0;
    padding: 0 2rem;
    border-radius: 0.25rem;
    height: 3rem;
    margin: 0.5rem;
    transition: width 0.4s ease-in-out;
    &:hover {
      filter: brightness(0.5);
    }
  }
`;

export const DashboardContainer = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: center;

  input {
    height: 3rem;
    margin: 0.5rem;
    border-radius: 0.5rem;
    border: 1px solid #d7d7d7;
    background-color: #e7e9ee;
    text-align: center;
    font-weight: bold;
  }
`;
