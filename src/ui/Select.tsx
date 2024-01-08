import styled from "styled-components";

// Define TypeScript interface for StyledSelect props
interface StyledSelectProps {
  type?: 'white' | 'default';  // Assuming 'white' and 'default' are your intended types for the 'type' prop
}

// Update the StyledSelect to use the StyledSelectProps interface
const StyledSelect = styled.select<StyledSelectProps>`
  font-size: 1.4rem;
  padding: 0.8rem 1.2rem;
  border: 1px solid
    ${(props) =>
      props.type === "white"
        ? "var(--color-grey-100)"
        : "var(--color-grey-300)"};
  border-radius: var(--border-radius-sm);
  background-color: var(--color-grey-0);
  font-weight: 500;
  box-shadow: var(--shadow-sm);
`;


