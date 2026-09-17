import { useVideo } from "../features/videos/useVideo";
import { VideoView } from "../features/videos/components/videoView/VideoView";

const VIDEO_ID = 123

export const VideoPage = () => {
  const { data: video, isLoading, error } = useVideo(VIDEO_ID)

  return (
    <VideoView
      video={video}
      isLoading={isLoading}
      error={error}
    />
  )
}
