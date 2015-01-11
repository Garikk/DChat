' DZFS.NET 2003 - 2005
' DChat Project
' IRC Server Message public constants
' DCIRC
'------------------------------------------------------------------------------------
' Programmed by Garikk 
' IRC public constants (IRC RFC2812)
' Ver 1.1
'------------------------------------------------------------------------------------

Module IRCConst


    'Not in RFC

    Public Const ERR_ALREADYONCHL_NOTRFC As Integer = 927


    '5.1 Command responses

    '   Numerics in the range from 001 to 099 are used for client-server
    '   connections only and should never travel between servers.  Replies
    '   generated in the response to commands are found in the range from 200
    '   to 399.

    Public Const RPL_WELCOME As Integer = 1
    ' "Welcome to the Internet Relay Network
    '  <nick>!<user>@<host>"
    Public Const RPL_YOURHOST As Integer = 2
    '       "Your host is <servername>, running version <ver>"
    Public Const RPL_CREATED As Integer = 3
    '"This server was created <date>"
    Public Const RPL_MYINFO As Integer = 4
    '"<servername> <version> <available user modes>
    '<available channel modes>"

    '- The server sends Replies 001 to 004 to a user upon
    '  successful registration.


    Public Const RPL_ISUPPORT As Integer = 5
    ' :irc.example.org 005 nick PREFIX=(ov)@+ CHANTYPES=#& :are supported by this server

    Public Const RPL_USERHOST As Integer = 302
    ' ":*1<reply> *( " " <reply> )"

    '- Reply format used by USERHOST to list replies to
    ' the query list.  The reply string is composed as
    'follows:

    'reply = nickname [ "*" ] "=" ( "+" / "-" ) hostname

    'The '*' indicates whether the client has registered
    'as an Operator.  The '-' or '+' characters represent
    'whether the client has set an AWAY message or not
    'respectively.

    Public Const RPL_ISON As Integer = 303
    '   ":*1<nick> *( " " <nick> )"

    ' - Reply format used by ISON to list replies to the
    '   query list.

    Public Const RPL_AWAY As Integer = 301
    '   "<nick> :<away message>"
    Public Const RPL_UNAWAY As Integer = 305
    '   ":You are no longer marked as being away"
    Public Const RPL_NOWAWAY As Integer = 306
    '  ":You have been marked as being away"

    '- These replies are used with the AWAY command (if
    ' allowed).  RPL_AWAY is sent to any client sending a
    'PRIVMSG to a client which is away.  RPL_AWAY is only
    'sent by the server to which the client is connected.
    'Replies RPL_UNAWAY and RPL_NOWAWAY are sent when the
    'client removes and sets an AWAY message.

    Public Const RPL_WHOISUSER As Integer = 311
    '   "<nick> <user> <host> * :<real name>"
    Public Const RPL_WHOISSERVER As Integer = 312
    ' "<nick> <server> :<server info>"
    Public Const RPL_WHOISOPERATOR As Integer = 313
    '  "<nick> :is an IRC operator"


    Public Const RPL_ACTUALLY_NOTRFC As Integer = 338


    Public Const RPL_WHOISIDLE As Integer = 317
    ' "<nick> <integer> :seconds idle"
    Public Const RPL_ENDOFWHOIS As Integer = 318
    '   "<nick> :End of WHOIS list"
    Public Const RPL_WHOISCHANNELS As Integer = 319
    ' "<nick> :*( ( "@" / "+" ) <channel> " " )"

    '- Replies 311 - 313, 317 - 319 are all replies
    '  generated in response to a WHOIS message.  Given that
    '  there are enough parameters present, the answering
    '  server MUST either formulate a reply out of the above
    '  numerics (if the query nick is found) or return an
    '  error reply.  The '*' in RPL_WHOISUSER is there as
    '  the literal character and not as a wild card.  For
    '  each reply set, only RPL_WHOISCHANNELS may appear
    '  more than once (for long lists of channel names).
    '  The '@' and '+' characters next to the channel name
    '  indicate whether a client is a channel operator or
    '  has been granted permission to speak on a moderated
    '  channel.  The RPL_ENDOFWHOIS reply is used to mark
    '  the end of processing a WHOIS message.

    Public Const RPL_WHOWASUSER As Integer = 314
    ' "<nick> <user> <host> * :<real name>"
    Public Const RPL_ENDOFWHOWAS As Integer = 369
    '  "<nick> :End of WHOWAS"

    ' - When replying to a WHOWAS message, a server MUST use
    '   the replies RPL_WHOWASUSER, RPL_WHOISSERVER or
    '   ERR_WASNOSUCHNICK for each nickname in the presented
    '   list.  At the end of all reply batches, there MUST
    '   be RPL_ENDOFWHOWAS (even if there was only one reply
    '   and it was an error).

    Public Const RPL_LISTSTART As Integer = 321
    '     Obsolete. Not used.

    Public Const RPL_LIST As Integer = 322
    '    "<channel> <# visible> :<topic>"
    Public Const RPL_LISTEND As Integer = 323
    '   ":End of LIST"

    '- Replies RPL_LIST, RPL_LISTEND mark the actual replies
    '  with data and end of the server's response to a LIST
    '  command.  If there are no channels available to return,
    '  only the end reply MUST be sent.

    Public Const RPL_UNIQOPIS As Integer = 325
    '  "<channel> <nickname>"

    Public Const RPL_CHANNELMODEIS As Integer = 324
    '   "<channel> <mode> <mode params>"

    Public Const RPL_NOTOPIC As Integer = 331
    '  "<channel> :No topic is set"
    Public Const RPL_TOPIC As Integer = 332
    ' "<channel> :<topic>"

    '- When sending a TOPIC message to determine the
    '  channel topic, one of two replies is sent.  If
    '  the topic is set, RPL_TOPIC is sent back else
    '  RPL_NOTOPIC.
    Public Const RPL_TOPIC_CHANGER_NOTRFC As Integer = 333
    Public Const RPL_CHLCREATIONDATE_NOTRFC As Integer = 329
    Public Const RPL_INVITING As Integer = 341
    '     "<channel> <nick>"

    '- Returned by the server to indicate that the
    '  attempted INVITE message was successful and is
    '  being passed onto the end client.

    Public Const RPL_SUMMONING As Integer = 342
    '     "<user> :Summoning user to IRC"

    '- Returned by a server answering a SUMMON message to
    '  indicate that it is summoning that user.

    Public Const RPL_INVITELIST As Integer = 346
    '     "<channel> <invitemask>"
    Public Const RPL_ENDOFINVITELIST As Integer = 347
    '    "<channel> :End of channel invite list"

    '- When listing the 'invitations masks' for a given channel,
    '  a server is required to send the list back using the
    '  RPL_INVITELIST and RPL_ENDOFINVITELIST messages.  A
    '  separate RPL_INVITELIST is sent for each active mask.
    '  After the masks have been listed (or if none present) a
    '  RPL_ENDOFINVITELIST MUST be sent.

    Public Const RPL_EXCEPTLIST As Integer = 348
    ' "<channel> <exceptionmask>"
    Public Const RPL_ENDOFEXCEPTLIST As Integer = 349
    ' "<channel> :End of channel exception list"


    '- When listing the 'exception masks' for a given channel,
    '  a server is required to send the list back using the
    '  RPL_EXCEPTLIST and RPL_ENDOFEXCEPTLIST messages.  A
    '  separate RPL_EXCEPTLIST is sent for each active mask.
    '  After the masks have been listed (or if none present)
    '  a RPL_ENDOFEXCEPTLIST MUST be sent.

    Public Const RPL_VERSION As Integer = 351
    '     "<version>.<debuglevel> <server> :<comments>"

    '- Reply by the server showing its version details.
    '  The <version> is the version of the software being
    '  used (including any patchlevel revisions) and the
    '  <debuglevel> is used to indicate if the server is
    '  running in "debug mode".

    '  The "comments" field may contain any comments about
    '  the version or further version details.

    Public Const RPL_WHOREPLY As Integer = 352
    '"<channel> <user> <host> <server> <nick>
    '( "H" / "G" > ["*"] [ ( "@" / "+" ) ]
    ':<hopcount> <real name>"

    Public Const RPL_ENDOFWHO As Integer = 315
    '     "<name> :End of WHO list"

    '- The RPL_WHOREPLY and RPL_ENDOFWHO pair are used
    '  to answer a WHO message.  The RPL_WHOREPLY is only
    '  sent if there is an appropriate match to the WHO
    '  query.  If there is a list of parameters supplied
    '  with a WHO message, a RPL_ENDOFWHO MUST be sent
    '  after processing each list item with <name> being
    '  the item.

    Public Const RPL_NAMREPLY As Integer = 353
    '     "( "=" / "*" / "@" ) <channel>
    '      :[ "@" / "+" ] <nick> *( " " [ "@" / "+" ] <nick> )
    '- "@" is used for secret channels, "*" for private
    '  channels, and "=" for others (public channels).

    Public Const RPL_ENDOFNAMES As Integer = 366
    '     "<channel> :End of NAMES list"

    '- To reply to a NAMES message, a reply pair consisting
    '  of RPL_NAMREPLY and RPL_ENDOFNAMES is sent by the
    '  server back to the client.  If there is no channel
    '  found as in the query, then only RPL_ENDOFNAMES is
    'returned.  The exception to this is when a NAMES
    'message is sent with no parameters and all visible
    'channels and contents are sent back in a series of
    'RPL_NAMEREPLY messages with a RPL_ENDOFNAMES to mark
    'the end.

    Public Const RPL_LINKS As Integer = 364
    ' "<mask> <server> :<hopcount> <server info>"
    Public Const RPL_ENDOFLINKS As Integer = 365
    '   "<mask> :End of LINKS list"

    '- In replying to the LINKS message, a server MUST send
    '  replies back using the RPL_LINKS numeric and mark the
    '  end of the list using an RPL_ENDOFLINKS reply.

    Public Const RPL_BANLIST As Integer = 367
    '    "<channel> <banmask>"
    Public Const RPL_ENDOFBANLIST As Integer = 368
    '   "<channel> :End of channel ban list"

    '- When listing the active 'bans' for a given channel,
    '  a server is required to send the list back using the
    '  RPL_BANLIST and RPL_ENDOFBANLIST messages.  A separate
    '  RPL_BANLIST is sent for each active banmask.  After the
    '  banmasks have been listed (or if none present) a
    '  RPL_ENDOFBANLIST MUST be sent.

    Public Const RPL_INFO As Integer = 371
    ' ":<string>"
    Public Const RPL_ENDOFINFO As Integer = 374
    ' ":End of INFO list"

    '- A server responding to an INFO message is required to
    '  send all its 'info' in a series of RPL_INFO messages
    '  with a RPL_ENDOFINFO reply to indicate the end of the
    '  replies.

    Public Const RPL_MOTDSTART As Integer = 375
    '   ":- <server> Message of the day - "
    Public Const RPL_MOTD As Integer = 372
    '   ":- <text>"
    Public Const RPL_ENDOFMOTD As Integer = 376
    '  ":End of MOTD command"

    '- When responding to the MOTD message and the MOTD file
    '  is found, the file is displayed line by line, with
    '  each line no longer than 80 characters, using

    'RPL_MOTD format replies.  These MUST be surrounded
    'by a RPL_MOTDSTART (before the RPL_MOTDs) and an
    'RPL_ENDOFMOTD (after).

    Public Const RPL_YOUREOPER As Integer = 381
    '  ":You are now an IRC operator"

    '- RPL_YOUREOPER is sent back to a client which has
    '  just successfully issued an OPER message and gained
    '  operator status.

    Public Const RPL_REHASHING As Integer = 382
    '   "<config file> :Rehashing"

    '- If the REHASH option is used and an operator sends
    '  a REHASH message, an RPL_REHASHING is sent back to
    '  the operator.

    Public Const RPL_YOURESERVICE As Integer = 383
    '    "You are service <servicename>"

    '- Sent by the server to a service upon successful
    '  registration.

    Public Const RPL_TIME As Integer = 391
    '      "<server> :<string showing server's local time>"

    '- When replying to the TIME message, a server MUST send
    '  the reply using the RPL_TIME format above.  The string
    '  showing the time need only contain the correct day and
    '  time there.  There is no further requirement for the
    '  time string.

    Public Const RPL_USERSSTART As Integer = 392
    '   ":UserID   Terminal  Host"
    Public Const RPL_USERS As Integer = 393
    '   ":<username> <ttyline> <hostname>"
    Public Const RPL_ENDOFUSERS As Integer = 394
    '   ":End of users"
    Public Const RPL_NOUSERS As Integer = 395
    '  ":Nobody logged in"

    '- If the USERS message is handled by a server, the
    '  replies RPL_USERSTART, RPL_USERS, RPL_ENDOFUSERS and
    '  RPL_NOUSERS are used.  RPL_USERSSTART MUST be sent
    '  first, following by either a sequence of RPL_USERS
    '  or a single RPL_NOUSER.  Following this is
    '  RPL_ENDOFUSERS.

    Public Const RPL_TRACELINK As Integer = 200
    '  "Link <version & debug level> <destination>
    '<next server> V<protocol version>
    '<link uptime in seconds> <backstream sendq>
    '<upstream sendq>"
    Public Const RPL_TRACECONNECTING As Integer = 201
    '   "Try. <class> <server>"
    Public Const RPL_TRACEHANDSHAKE As Integer = 202
    ' "H.S. <class> <server>"
    Public Const RPL_TRACEUNKNOWN As Integer = 203
    ' "???? <class> [<client IP address in dot form>]"
    Public Const RPL_TRACEOPERATOR As Integer = 204
    '"Oper <class> <nick>"
    Public Const RPL_TRACEUSER As Integer = 205
    '"User <class> <nick>"
    Public Const RPL_TRACESERVER As Integer = 206
    '"Serv <class> <int>S <int>C <server>
    ' <nick!user|*!*>@<host|server> V<protocol version>"
    Public Const RPL_TRACESERVICE As Integer = 207
    '    "Service <class> <name> <type> <active type>"
    Public Const RPL_TRACENEWTYPE As Integer = 208
    '    "<newtype> 0 <client name>"
    Public Const RPL_TRACECLASS As Integer = 209
    '    "Class <class> <count>"
    Public Const RPL_TRACERECONNECT As Integer = 210
    '    Unused.
    Public Const RPL_TRACELOG As Integer = 261
    '   "File <logfile> <debug level>"
    Public Const RPL_TRACEEND As Integer = 262
    '    "<server name> <version & debug level> :End of TRACE"

    '- The RPL_TRACE* are all returned by the server in
    '  response to the TRACE message.  How many are
    '  returned is dependent on the TRACE message and
    '  whether it was sent by an operator or not.  There
    '  is no predefined order for which occurs first.
    '  Replies RPL_TRACEUNKNOWN, RPL_TRACECONNECTING and
    '  RPL_TRACEHANDSHAKE are all used for connections
    '  which have not been fully established and are either
    '  unknown, still attempting to connect or in the
    '  process of completing the 'server handshake'.
    '  RPL_TRACELINK is sent by any server which handles
    '  a TRACE message and has to pass it on to another
    '  server.  The list of RPL_TRACELINKs sent in
    '  response to a TRACE command traversing the IRC
    '  network should reflect the actual connectivity of
    '  the servers themselves along that path.

    'RPL_TRACENEWTYPE is to be used for any connection
    ' which does not fit in the other categories but is
    ' being displayed anyway.
    ' RPL_TRACEEND is sent to indicate the end of the list.

    Public Const RPL_STATSLINKINFO As Integer = 211
    '     "<linkname> <sendq> <sent messages>
    '      <sent Kbytes> <received messages>
    '      <received Kbytes> <time open>"

    '- reports statistics on a connection.  <linkname>
    '  identifies the particular connection, <sendq> is
    '  the amount of data that is queued and waiting to be
    '  sent <sent messages> the number of messages sent,
    '  and <sent Kbytes> the amount of data sent, in
    '  Kbytes. <received messages> and <received Kbytes>
    '  are the equivalent of <sent messages> and <sent
    '  Kbytes> for received data, respectively.  <time
    '  open> indicates how long ago the connection was
    '  opened, in seconds.

    Public Const RPL_STATSCOMMANDS As Integer = 212
    '     "<command> <count> <byte count> <remote count>"

    '- reports statistics on commands usage.

    Public Const RPL_ENDOFSTATS As Integer = 219
    '      "<stats letter> :End of STATS report"

    Public Const RPL_STATSUPTIME As Integer = 242
    '      ":Server Up %d days %d:%02d:%02d"

    ' - reports the server uptime.

    Public Const RPL_STATSOLINE As Integer = 243
    '      "O <hostmask> * <name>"

    '  - reports the allowed hosts from where user may become IRC
    '    operators.

    Public Const RPL_UMODEIS As Integer = 221
    '     "<user mode string>"

    '- To answer a query about a client's own mode,
    '    RPL_UMODEIS is sent back.

    Public Const RPL_SERVLIST As Integer = 234
    '      "<name> <server> <mask> <type> <hopcount> <info>"


    Public Const RPL_SERVLISTEND As Integer = 235
    '  "<mask> <type> :End of service listing"

    '- When listing services in reply to a SERVLIST message,
    '  a server is required to send the list back using the
    '  RPL_SERVLIST and RPL_SERVLISTEND messages.  A separate
    '  RPL_SERVLIST is sent for each service.  After the
    '  services have been listed (or if none present) a
    '  RPL_SERVLISTEND MUST be sent.

    Public Const RPL_LUSERCLIENT As Integer = 251
    '":There are <integer> users and <integer>
    ' services on <integer> servers"
    Public Const RPL_LUSEROP As Integer = 252
    '      "<integer> :operator(s) online"
    Public Const RPL_LUSERUNKNOWN As Integer = 253
    '     "<integer> :unknown connection(s)"
    Public Const RPL_LUSERCHANNELS As Integer = 254
    '     "<integer> :channels formed"
    Public Const RPL_LUSERME As Integer = 255
    '     ":I have <integer> clients and <integer>
    '       servers"

    '- In processing an LUSERS message, the server
    '  sends a set of replies from RPL_LUSERCLIENT,
    '  RPL_LUSEROP, RPL_USERUNKNOWN,
    '  RPL_LUSERCHANNELS and RPL_LUSERME.  When
    '  replying, a server MUST send back
    '  RPL_LUSERCLIENT and RPL_LUSERME.  The other
    '  replies are only sent back if a non-zero count
    '  is found for them.

    Public Const RPL_ADMINME As Integer = 256
    '       "<server> :Administrative info"
    Public Const RPL_ADMINLOC1 As Integer = 257
    '     ":<admin info>"
    Public Const RPL_ADMINLOC2 As Integer = 258
    '    ":<admin info>"
    Public Const RPL_ADMINEMAIL As Integer = 259
    '    ":<admin info>"

    '- When replying to an ADMIN message, a server
    '  is expected to use replies RPL_ADMINME
    '  through to RPL_ADMINEMAIL and provide a text
    '  message with each.  For RPL_ADMINLOC1 a
    '  description of what city, state and country
    '  the server is in is expected, followed by
    '  details of the institution (RPL_ADMINLOC2)

    'and finally the administrative contact for the
    'server (an email address here is REQUIRED)
    'in RPL_ADMINEMAIL.

    Public Const RPL_TRYAGAIN As Integer = 263
    '      "<command> :Please wait a while and try again."

    '- When a server drops a command without processing it,
    '  it MUST use the reply RPL_TRYAGAIN to inform the
    '  originating client.

    '5.2 Error Replies

    '       Error replies are found in the range from 400 to 599.

    Public Const ERR_NOSUCHNICK As Integer = 401
    '    "<nickname> :No such nick/channel"

    '- Used to indicate the nickname parameter supplied to a
    '  command is currently unused.

    Public Const ERR_NOSUCHSERVER As Integer = 402
    '     "<server name> :No such server"

    '- Used to indicate the server name given currently
    '  does not exist.

    Public Const ERR_NOSUCHCHANNEL As Integer = 403
    '     "<channel name> :No such channel"

    '- Used to indicate the given channel name is invalid.

    Public Const ERR_CANNOTSENDTOCHAN As Integer = 404
    '     "<channel name> :Cannot send to channel"

    '- Sent to a user who is either (a) not on a channel
    '  which is mode +n or (b) not a chanop (or mode +v) on
    '  a channel which has mode +m set or where the user is
    '  banned and is trying to send a PRIVMSG message to
    '  that channel.

    Public Const ERR_TOOMANYCHANNELS As Integer = 405
    '     "<channel name> :You have joined too many channels"

    '- Sent to a user when they have joined the maximum
    '  number of allowed channels and they try to join
    '  another channel.

    Public Const ERR_WASNOSUCHNICK As Integer = 406
    '     "<nickname> :There was no such nickname"

    '- Returned by WHOWAS to indicate there is no history
    '  information for that nickname.

    Public Const ERR_TOOMANYTARGETS As Integer = 407
    '     "<target> :<error code> recipients. <abort message>"

    '- Returned to a client which is attempting to send a
    '  PRIVMSG/NOTICE using the user@host destination format
    '  and for a user@host which has several occurrences.

    '- Returned to a client which trying to send a
    '  PRIVMSG/NOTICE to too many recipients.

    '- Returned to a client which is attempting to JOIN a safe
    '  channel using the shortname when there are more than one
    '  such channel.

    Public Const ERR_NOSUCHSERVICE As Integer = 408
    '     "<service name> :No such service"

    '- Returned to a client which is attempting to send a SQUERY
    '  to a service which does not exist.

    Public Const ERR_NOORIGIN As Integer = 409
    '":No origin specified"

    '- PING or PONG message missing the originator parameter.

    Public Const ERR_NORECIPIENT As Integer = 411
    '        ":No recipient given (<command>)"
    Public Const ERR_NOTEXTTOSEND As Integer = 412
    '      ":No text to send"
    Public Const ERR_NOTOPLEVEL As Integer = 413
    '      "<mask> :No toplevel domain specified"
    Public Const ERR_WILDTOPLEVEL As Integer = 414
    '     "<mask> :Wildcard in toplevel domain"
    Public Const ERR_BADMASK As Integer = 415
    '      "<mask> :Bad Server/host mask"

    '- 412 - 415 are returned by PRIVMSG to indicate that
    '  the message wasn't delivered for some reason.
    '  ERR_NOTOPLEVEL and ERR_WILDTOPLEVEL are errors that
    '  are returned when an invalid use of
    '  "PRIVMSG $<server>" or "PRIVMSG #<host>" is attempted.



    Public Const ERR_UNKNOWNCOMMAND As Integer = 421
    '       "<command> :Unknown command"

    '- Returned to a registered client to indicate that the
    '  command sent is unknown by the server.

    Public Const ERR_NOMOTD As Integer = 422
    '      ":MOTD File is missing"

    '  - Server's MOTD file could not be opened by the server.

    Public Const ERR_NOADMININFO As Integer = 423
    '     "<server> :No administrative info available"

    '- Returned by a server in response to an ADMIN message
    '  when there is an error in finding the appropriate
    '  information.

    Public Const ERR_FILEERROR As Integer = 424
    '     ":File error doing <file op> on <file>"

    '- Generic error message used to report a failed file
    '  operation during the processing of a message.

    Public Const ERR_NONICKNAMEGIVEN As Integer = 431
    '     ":No nickname given"

    '- Returned when a nickname parameter expected for a
    '  command and isn't found.

    Public Const ERR_ERRONEUSNICKNAME As Integer = 432
    '     "<nick> :Erroneous nickname"

    '- Returned after receiving a NICK message which contains
    '  characters which do not fall in the defined set.  See
    '  section 2.3.1 for details on valid nicknames.

    Public Const ERR_NICKNAMEINUSE As Integer = 433
    '     "<nick> :Nickname is already in use"

    '- Returned when a NICK message is processed that results
    '  in an attempt to change to a currently existing
    '  nickname.

    Public Const ERR_NICKCOLLISION As Integer = 436
    '     "<nick> :Nickname collision KILL from <user>@<host>"

    '- Returned by a server to a client when it detects a
    '  nickname collision (registered of a NICK that
    '  already exists by another server).

    Public Const ERR_UNAVAILRESOURCE As Integer = 437
    '     "<nick/channel> :Nick/channel is temporarily unavailable"

    '- Returned by a server to a user trying to join a channel
    '  currently blocked by the channel delay mechanism.

    '- Returned by a server to a user trying to change nickname
    '  when the desired nickname is blocked by the nick delay
    '  mechanism.

    Public Const ERR_USERNOTINCHANNEL As Integer = 441
    '     "<nick> <channel> :They aren't on that channel"

    '- Returned by the server to indicate that the target
    '  user of the command is not on the given channel.

    Public Const ERR_NOTONCHANNEL As Integer = 442
    '     "<channel> :You're not on that channel"

    '- Returned by the server whenever a client tries to
    '  perform a channel affecting command for which the
    '  client isn't a member.

    Public Const ERR_USERONCHANNEL As Integer = 443
    '     "<user> <channel> :is already on channel"

    '- Returned when a client tries to invite a user to a
    '  channel they are already on.

    Public Const ERR_NOLOGIN As Integer = 444
    '     "<user> :User not logged in"

    '- Returned by the summon after a SUMMON command for a
    '  user was unable to be performed since they were not
    '  logged in.

    Public Const ERR_SUMMONDISABLED As Integer = 445
    '     ":SUMMON has been disabled"

    '- Returned as a response to the SUMMON command.  MUST be
    '  returned by any server which doesn't implement it.

    Public Const ERR_USERSDISABLED As Integer = 446
    '     ":USERS has been disabled"

    '- Returned as a response to the USERS command.  MUST be
    '  returned by any server which does not implement it.

    Public Const ERR_NOTREGISTERED As Integer = 451
    '     ":You have not registered"

    '- Returned by the server to indicate that the client
    '  MUST be registered before the server will allow it
    '  to be parsed in detail.

    Public Const ERR_NEEDMOREPARAMS As Integer = 461
    '     "<command> :Not enough parameters"

    '- Returned by the server by numerous commands to
    '  indicate to the client that it didn't supply enough
    '  parameters.

    Public Const ERR_ALREADYREGISTRED As Integer = 462
    '     ":Unauthorized command (already registered)"

    '- Returned by the server to any link which tries to
    '  change part of the registered details (such as
    '  password or user details from second USER message).

    Public Const ERR_NOPERMFORHOST As Integer = 463
    '     ":Your host isn't among the privileged"

    '- Returned to a client which attempts to register with
    '  a server which does not been setup to allow
    '  connections from the host the attempted connection
    '  is tried.

    Public Const ERR_PASSWDMISMATCH As Integer = 464
    '     ":Password incorrect"

    '- Returned to indicate a failed attempt at registering
    '  a connection for which a password was required and
    '  was either not given or incorrect.


    Public Const ERR_YOUREBANNEDCREEP As Integer = 465
    '     ":You are banned from this server"

    '- Returned after an attempt to connect and register
    '  yourself with a server which has been setup to
    '  explicitly deny connections to you.

    Public Const ERR_YOUWILLBEBANNED As Integer = 466

    '- Sent by a server to a user to inform that access to the
    '  server will soon be denied.

    Public Const ERR_KEYSET As Integer = 467
    '      "<channel> :Channel key already set"
    Public Const ERR_CHANNELISFULL As Integer = 471
    '    "<channel> :Cannot join channel (+l)"
    Public Const ERR_UNKNOWNMODE As Integer = 472
    '   "<char> :is unknown mode char to me for <channel>"
    Public Const ERR_INVITEONLYCHAN As Integer = 473
    '    "<channel> :Cannot join channel (+i)"
    Public Const ERR_BANNEDFROMCHAN As Integer = 474
    '    "<channel> :Cannot join channel (+b)"
    Public Const ERR_BADCHANNELKEY As Integer = 475
    '   "<channel> :Cannot join channel (+k)"
    Public Const ERR_BADCHANMASK As Integer = 476
    '   "<channel> :Bad Channel Mask"
    Public Const ERR_NOCHANMODES As Integer = 477
    '      "<channel> :Channel doesn't support modes"
    Public Const ERR_BANLISTFULL As Integer = 478
    '     "<channel> <char> :Channel list is full"

    Public Const ERR_NOPRIVILEGES As Integer = 481
    '      ":Permission Denied- You're not an IRC operator"

    '- Any command requiring operator privileges to operate
    '  MUST return this error to indicate the attempt was
    '  unsuccessful.

    Public Const ERR_CHANOPRIVSNEEDED As Integer = 482
    '     "<channel> :You're not channel operator"

    '- Any command requiring 'chanop' privileges (such as
    '  MODE messages) MUST return this error if the client
    '  making the attempt is not a chanop on the specified
    '  channel.


    Public Const ERR_CANTKILLSERVER As Integer = 483
    '    ":You can't kill a server!"

    '- Any attempts to use the KILL command on a server
    '  are to be refused and this error returned directly
    '  to the client.

    Public Const ERR_RESTRICTED As Integer = 484
    '     ":Your connection is restricted!"

    '- Sent by the server to a user upon connection to indicate
    '  the restricted nature of the connection (user mode "+r").

    Public Const ERR_UNIQOPPRIVSNEEDED As Integer = 485
    '     ":You're not the original channel operator"

    '- Any MODE requiring "channel creator" privileges MUST
    '  return this error if the client making the attempt is not
    '  a chanop on the specified channel.

    Public Const ERR_NOOPERHOST As Integer = 491
    '     ":No O-lines for your host"

    '- If a client sends an OPER message and the server has
    '  not been configured to allow connections from the
    '  client's host as an operator, this error MUST be
    '  returned.

    Public Const ERR_UMODEUNKNOWNFLAG As Integer = 501
    '     ":Unknown MODE flag"

    '- Returned by the server to indicate that a MODE
    '  message was sent with a nickname parameter and that
    '  the a mode flag sent was not recognized.

    Public Const ERR_USERSDONTMATCH As Integer = 502
    '              ":Cannot change mode for other users"

    '         - Error sent to any user trying to view or change the
    '           user mode for a user other than themselves.

    '5.3 Reserved numerics

    '   These numerics are not described above since they fall into one of
    '   the following categories:

    '   1. no longer in use;




    'Kalt                         Informational                     [Page 59]

    'RFC 2812          Internet Relay Chat: Client Protocol        April 2000


    '   2. reserved for future planned use;

    '   3. in current use but are part of a non-generic 'feature' of
    '      the current IRC server.

    '            231    RPL_SERVICEINFO     232  RPL_ENDOFSERVICES
    '            233    RPL_SERVICE
    '            300    RPL_NONE            316  RPL_WHOISCHANOP
    '            361    RPL_KILLDONE        362  RPL_CLOSING
    '            363    RPL_CLOSEEND        373  RPL_INFOSTART
    '            384    RPL_MYPORTIS

    '            213    RPL_STATSCLINE      214  RPL_STATSNLINE
    '            215    RPL_STATSILINE      216  RPL_STATSKLINE
    '            217    RPL_STATSQLINE      218  RPL_STATSYLINE
    '            240    RPL_STATSVLINE      241  RPL_STATSLLINE
    '            244    RPL_STATSHLINE      244  RPL_STATSSLINE
    '            246    RPL_STATSPING       247  RPL_STATSBLINE
    '            250    RPL_STATSDLINE

    '            492    ERR_NOSERVICEHOST
End Module
