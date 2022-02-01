import { createGlobalStyle } from "styled-components";

export const GlobalStyle = createGlobalStyle`

    :root {
        --blue-light: #6933FF;

        --background: #f0f2f5;
        --shape: #FFFFFF;
        
        width: 100%;
        height:100%;

        background: var(--blue-light);
    }


  *{
      margin: 0;
      padding: 0;
      box-sizing: border-box;
  }

  button{
      cursor: pointer;
  }

  html {
      @media(max-width: 1080px){
          font-size: 93.75px;
      }

      @media(max-width: 720px){
          font-size: 87.5%;
      }
  }
`;
