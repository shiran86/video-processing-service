import { login } from "../service";

export const LoginButton = () => {
    return (
        <button onClick={login} >
            Login
        </button>
    );
}