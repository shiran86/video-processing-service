import { useState } from 'react'
import { VideoClips } from '../features/videos/components/videoClips/VideoClips'
import type { VideoClip } from '../features/videos/components/videoClips/types'
import { VideoPlayer } from '../features/videos/components/videoPlayer/VideoPlayer'
import { useVideo } from '../features/videos/useVideo'

const VIDEO_ID = 123

export const VideoPage = () => {
  const { data: video, isLoading, error } = useVideo(VIDEO_ID)
  const [clips] = useState<VideoClip[]>([
    { start: 2, end: 3 },
    { start: 7, end: 8 },
  ])

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

      <VideoClips clips={clips} />
    </div>
  )
}
