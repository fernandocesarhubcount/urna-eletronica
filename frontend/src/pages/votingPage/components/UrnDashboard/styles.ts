import styled from "styled-components";

export const UrnDashboardStyle = styled.div`
  width: 20%;
  justify-content: center;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  margin-left: 33.9rem;
  margin-top: 9rem;

  input {
    width: 15.7rem;
    padding: 12px 20px;
    margin: 8px;
    box-sizing: border-box;
    transition: width 0.4s ease-in-out;
    border-radius: 0.3rem;
  }

  .optionButtons {
    display: flex;
    flex-direction: row;
    width: 97%;

    .undoButton {
      background: #ff9900;
      width: 50%;
      color: var(--shape);
    }

    .voteButton {
      background: #0cff57;
      width: 50%;
      color: var(--shape);
    }
  }

  button {
    font-size: 1rem;
    font-weight: bold;
    color: #000;
    background: var(--shape);
    border: 0;
    padding: 0 2rem;
    border-radius: 0.25rem;
    height: 3rem;
    margin: 0.5rem;
    &:hover {
      filter: brightness(0.5);
    }
  }
`;
