import { useEffect, useState } from 'react'
import { VideoPlayer } from '../components/videoPlayer/VideoPlayer'
import { getVideo } from './services'
import type { Video } from './types'

export const VideoPage = () => {
  const [video, setVideo] = useState<Video | null>(null)

  useEffect(() => {
    const fetchVideo = async() => {
      const video = await getVideo();
      setVideo(video)
    }
    fetchVideo()
  }, [])

  if (!video) {
    return <div>Loading...</div>
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