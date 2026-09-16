import './App.css'
import { AuthGuard } from './features/auth/components/AuthGuard/AuthGuard'
import { LoginView } from './features/auth/components/LoginView'
import { UserView } from './features/auth/controllers/UserView'
import { VideoPage } from './features/videos/videoPage/VideoPage'

function App() {
  return (
    <AuthGuard fallback={<LoginView />}>
      <UserView />
      <VideoPage />
    </AuthGuard>
  )
}

export default App
