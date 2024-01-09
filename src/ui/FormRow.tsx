import styled, { css } from "styled-components";

interface FormRowProps {
  orientation?: 'vertical' | 'horizontal';
  label?: string;
  error?: string;
  children?: React.ReactNode; 
}

const StyledFormRow = styled.div<FormRowProps>`
  display: grid;
  align-items: center;

  grid-template-columns: ${(props) =>
    props.orientation === "vertical" ? "1fr" : "24rem 1fr 1.2fr"};
  gap: ${(props) => (props.orientation === "vertical" ? "0.8rem" : "2.4rem")};

  padding: 1.2rem 0;

  &:first-child {
    padding-top: 0;
  }

  &:last-child {
    padding-bottom: 0;
  }

  &:not(:last-child) {
    border-bottom: ${(props) =>
      props.orientation === "vertical"
        ? "none"
        : "1px solid var(--color-grey-100)"};
  }

  ${(props) =>
    props.orientation !== "vertical" &&
    css`
      &:has(button) {
        display: flex;
        justify-content: flex-end;
        gap: 1.2rem;
      }
    `}
`;

const Label = styled.label`
  font-weight: 500;
`;

const Error = styled.span`
  font-size: 1.4rem;
  color: var(--color-red-700);
`;

function FormRow({ label, error, children, orientation }: FormRowProps) {
  return (
    <StyledFormRow orientation={orientation}>
      {label && <Label>{label}</Label>}
      {children}
      {error && <Error>{error}</Error>}
    </StyledFormRow>
  );
}

export default FormRow;