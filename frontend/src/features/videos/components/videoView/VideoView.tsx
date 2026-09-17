import { VideoPlayer } from '../videoPlayer/VideoPlayer'
import type { Video } from './types'

type VideoViewProps = {
  video: Video | undefined
  isLoading: boolean
  error: Error | null
}

export const VideoView = ({ video, isLoading, error }: VideoViewProps) => {
  if (isLoading) {
    return <div>Loading...</div>
  }

  if (error) {
    return <div>Unable to load the video: {error.message}</div>
  }

  if (!video) {
    return <div>Video not found.</div>
  }

  return (
    <div>
      <h1>{video.name}</h1>

      <VideoPlayer
        src={video.preSignedUrl}
        controls
      />
    </div>
  )
}
